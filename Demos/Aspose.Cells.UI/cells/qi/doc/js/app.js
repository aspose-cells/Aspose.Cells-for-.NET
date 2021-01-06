(function () {
	'use strict';
	var app = angular.module('myApp', [
		'ngSanitize',
		'ngAnimate',
		'ngQuantum',
		'ngResource'
	]);

    app.value('NameList', customNameList);
    app.value('PageSrc', customPageSrc);

	app.run(['$templateCache', '$cacheFactory',
		function ($templateCache, $cacheFactory) {
			$templateCache = false;
		}]);

	app.config(['$httpProvider',
		function ($httpProvider) {
			$httpProvider.defaults.cache = false;
		}]);

	app.config(['$rootScopeProvider',
		function ($rootScopeProvider) {
			$rootScopeProvider.digestTtl(5);
		}]);

	app.factory('DocumentPagesFactory', function ($resource) {
		return $resource(apiURL + 'DocumentPages?product=' + productName + '&file=' + fileName + '&folderName=' + folderName + '&userEmail=none&pageCount=0&lstPages=null', {}, {
			query: {
				method: 'GET',
				isArray: false
			}
		});
	});

	app.directive('infinityscroll', function () {
		return {
			restrict: 'A',
			link: function (scope, element, attrs) {
				element.bind('scroll', function () {
					if ((element[0].scrollTop + element[0].offsetHeight) >= element[0].scrollHeight) {
						//scroll reach to end
						scope.$apply(attrs.infinityscroll);
					}
				});
			}
		}
	});

	app.directive('myEnter', function () {
		return function ($scope, element, attrs) {
			element.bind("keydown keypress", function (event) {
				if (event.which === 13) {
					$scope.$apply(function () {
						$scope.$eval(attrs.myEnter);
					});
					event.preventDefault();
				}
			});
		};
	});

    function GetPageData($scope, page, $http) {
        $scope.loading.show();
        $http({
            method: "GET",
            url: apiURL + 'DocumentPage?file=' + fileName + '&folderName=' + folderName + '&currentPage=' + page
        }).then(function (result) {
            const viewerResult = result.data;
            $scope.createPageImage(viewerResult["WorksheetPath"]);
            totalPages = viewerResult["WorksheetCount"];
            UpdatePager();
            document.getElementsByName("dvPages")[0].style.cssText = "height: 100vh; padding: 0; padding-top: 35px; width: auto!important; overflow: auto!important; background: none;";
            $scope.loading.hide();
        });
    }

	function GetWorksheetsNames($scope, $http) {
		$http({
			method: "GET",
			url: apiURL + 'GetWorksheetsNames?file=' + fileName + '&folderName=' + folderName
		}).then(function (result) {
            angular.forEach(result.data, function (value) {
                customNameList.push(value);
            });
            $scope.NameList = customNameList;
		});
	}

	app.controller('ViewerAPIController',
		function ViewerAPIController($scope, $sce, $http, $window, DocumentPagesFactory, $loading, $timeout, $q, $alert) {
			var $that = this;

			$scope.loadingButtonSucces = function () {
				return $timeout(function () {
					return true;
				}, 2000);
			};
			$scope.existApp = function () {
				if (callbackURL !== '')
					window.location = callbackURL + '?folderName=' + folderName + '&fileName=' + fileName;
				else if (featureName !== '')
					window.location = '/' + productName + '/viewer/' + featureName;
				else
					window.location = '/' + productName + '/viewer';
			};
			$scope.loading = new $loading({
				busyText: ' Please wait while page loading...',
				theme: 'info',
				timeout: false,
				showSpinner: true
			});


			$scope.getError = function () {
				var deferred = $q.defer();

				setTimeout(function () {
					deferred.reject('Error');
				}, 1000);
				return deferred.promise;
			}

			$scope.displayAlert = function (title, message, theme) {
				$alert(message, title, theme)
			}

            GetPageData($scope, currentSelectedPage, $http);
            GetWorksheetsNames($scope, $http);

            $scope.NextPage = function () {
                if (currentPageCount > totalPages) {
                    currentPageCount = totalPages;
                    return;
                }
                if (currentPageCount <= totalPages) {
                    currentPageCount += 1;
                    currentSelectedPage = currentPageCount;
                }
            }
            $scope.selected = false;
            $scope.slectedPageImage = function (event, PageData) {
                var domId = event.target.id.replace('img-page-', '').replace('imgt-page-', '');
                currentSelectedPage = parseInt(event.target.id.replace('img-page-', '').replace('imgt-page-', ''));

				GetPageData($scope, PageData["WorksheetIndex"], $http);

                if (event.target.id.startsWith('imgt-page-')) {
                    location.hash = 'page-view-' + domId;
                    $scope.selected = PageData["WorksheetIndex"];
                }
            }

            $scope.createPageImage = function (WorksheetPath) {
				customPageSrc = $sce.trustAsResourceUrl(apiURL + 'pagehtml?htmlPath=' + encodeURI(WorksheetPath));
                $scope.PageSrc = customPageSrc;
            }

			$scope.PageWidth = PageWidth;
			$scope.itemSelected = 'h';
			$scope.zoomPage = function (zoomOption) {
				if (zoomOption === 'w') {
					ZoomValue = 1
					$scope.itemSelected = zoomOption
					ZoomPages(parseFloat(ZoomValue.toString()));
				}
				else if (zoomOption === 'h') {
					ZoomValue = 0.65
					$scope.itemSelected = zoomOption
					ZoomPages(ZoomValue);
				}
				else {
					if (ZoomValue === 0.65)
						ZoomValue = 0.50;
					ZoomPages(zoomOption);
					$scope.itemSelected = ZoomValue;
				}
				//console.log('$scope.PageWidth = PageWidth;: ' + $scope.PageWidth);
				$scope.PageWidth = PageWidth;
				//console.log('ZoomValue selected in dll: ' + ZoomValue);
			}
		}
	);
})();