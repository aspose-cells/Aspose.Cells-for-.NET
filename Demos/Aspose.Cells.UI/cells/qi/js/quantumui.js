/*!
 * QuantumUI Free v1.0.0 (http://quantumui.org)
 * Copyright 2014-2015 Mehmet Otkun, quantumui.org
 */

/*!
 * QuantumUI Free v1.0.0 (http://quantumui.org)
 * Copyright 2014-2015 Mehmet Otkun, quantumui.org
 */
if (!String.prototype.trim) {
    String.prototype.trim = function () {
        return this.replace(/^\s+|\s+$/g, '');
    };
};
String.prototype.trimEnd = function (c) {
    var that = this.trim();
    if (c == null || c == "" || c.length > 1 || that.length < 2)
        return that;
    var s = that.slice(that.length - 1, that.length);
    if (s == c)
        return that.slice(0, this.length - 1);
    else
        return that;
};
String.prototype.trimStart = function (c) {
    var that = this.trim();
    if (c == null || c == "" || c.length > 1 || that.length < 2)
        return that;
    var s = that.slice(0, 1);
    if (s == c)
        return that.slice(1, that.length);
    else
        return that;
};
String.prototype.capitaliseFirstLetter = function () {
    return this.charAt(0).toUpperCase() + this.slice(1);
};
if (typeof String.prototype.endsWith !== 'function') {
    String.prototype.endsWith = function (suffix) {
        return this.indexOf(suffix, this.length - suffix.length) !== -1;
    };
};
String.prototype.toTitleCase = function (str) {
    var str = this || '';
    return str.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
};
String.prototype.replaceAll = function (find, replace) {
    var str = this || '';
    return str.replace(new RegExp(find, 'g'), replace);
};
if (typeof String.prototype.startsWith != 'function') {
    String.prototype.startsWith = function (str) {
        return this.slice(0, str.length) == str;
    };
};
if (typeof String.prototype.endsWith != 'function') {
    String.prototype.endsWith = function (str) {
        return this.slice(-str.length) == str;
    };
};
window.addResizeEvent = function (callback) {
    if (window.addEventListener) {
        window.addEventListener('resize', callback, true);
    }
    else if (window.attachEvent) {
        window.attachEvent('onresize', callback);
    }
};

+function (window, angular, undefined) {
    'use strict';
    var  $$raf  =
        window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame ||
        window.oRequestAnimationFrame ||
        window.msRequestAnimationFrame ||
        function (callback) {
            setTimeout(function () {
                callback.call(null, false)
            }, 150);
        };
    angular.element.prototype.removeClasses = function (classList) {
        var el = this;
        var list = angular.isArray(classList) ? classList : angular.isStrign(classList) ? classList.split(" ") : [];
        angular.forEach(list, function (val, key) {
            val && el.removeClass(val);
        })
        return this;
    }
   

    angular.element.prototype.animationEnd = function (callback) {
        var el = this;
        el.one('animationend webkitAnimationEnd oAnimationEnd oanimationend MSAnimationEnd',
            function (evt) {
                callback(evt);
            });
        $$raf(function (evt) {
            if (evt === false)
                callback(evt);
        })
        return this;
    }
    angular.element.prototype.transitionEnd = function (callback) {
        var el = this;
        
        el.one('transitionend webkitTransitionEnd oTransitionEnd otransitionend',
            function (evt) {
                callback(evt);
            });
        $$raf(function (evt) {
            if (evt === false)
                callback(evt);
        })
        return this;
    }
    var nqCoreApp = angular.module('ngQuantum.directives', [])
    angular.forEach(['Append', 'Prepend', 'Bind'], function (directive) {
        nqCoreApp.directive('nq' + directive, ['$compile', function ($compile) {
            return {
                restrict: 'A',
                link: function (scope, element, attr) {
                    var dirName = 'nq' + directive;
                    element.addClass('nq-' + directive.toLowerCase()).data('$nqbind', attr[dirName]);
                    scope.$watch(attr[dirName], function (value) {
                        ensureElement(value);
                    });
                    function bindElement(value) {
                        switch (dirName) {
                            case 'nqAppend':
                                element.append(value)
                                break;
                            case 'nqPrepend':
                                element.prepend(value)
                                break;
                            case 'nqBind':
                                element.html('')
                                element.append(value)
                                break;
                        }
                    }
                    function ensureElement(value) {
                        if (angular.isElement(value))
                            bindElement(value);
                        else {
                            if (angular.isString(value)) {
                                if (value.indexOf('{{') > -1 || value.indexOf('ng-bind') > -1) {
                                    var complied = angular.element(value);
                                    $compile(complied)(scope)
                                    bindElement(complied);
                                }
                                else if (value.indexOf('</') > -1 && value.indexOf('>') > -1)
                                    bindElement(angular.element(value));
                                else
                                    bindElement(value);
                            }
                        }
                    }
                }
            }
        }]);
    })
}(window, window.angular);


angular.module('ngQuantum.services.color', ['ngQuantum.services.helpers'])
.factory('$color', ['$helpers', function ($helpers) {
    var color = {};
    color.value = {
        h: 1,
        s: 1,
        b: 1,
        a: 1
    }
    color.setColor = function (val) {
        if (val) {
            val = val.toLowerCase();
            for (var key in $helpers.stringParsers) {
                if ($helpers.stringParsers.hasOwnProperty(key)) {
                    var parser = $helpers.stringParsers[key];
                    var match = parser.re.exec(val),
                        values = match && parser.parse(match);
                    if (values) {
                        color.value = color.RGBtoHSB.apply(null, values);
                        
                    }
                }
            }
        }
        return color;
    }
    color.RGBtoHSB = function (r, g, b, a) {
        r /= 255;
        g /= 255;
        b /= 255;

        var H, S, V, C;
        V = Math.max(r, g, b);
        C = V - Math.min(r, g, b);
        H = (C === 0 ? null :
            V === r ? (g - b) / C :
                V === g ? (b - r) / C + 2 :
                    (r - g) / C + 4
            );
        H = ((H + 360) % 6) * 60 / 360;
        S = C === 0 ? 0 : C / V;
        return { h: H || 1, s: S, b: V, a: a || 1 };
    }
    color.setHue = function (h) {
        color.value.h = h == 0 ? 0 : h == 1 ? 1 : h % 1;
    }
    color.setSaturation = function (s) {
        color.value.s = s == 0 ? 0 : s == 1 ? 1 : s % 1;
    }
    color.setLightness = function (b) {
        color.value.b = b == 0 ? 0 : b == 1 ? 1 : b % 1;
    }
    color.setAlpha = function (a) {
        color.value.a = parseInt((a == 0 ? 0 : a == 1 ? 1 : a % 1) * 100, 10) / 100;
    }
    color.toRGB = function (h, s, b, a) {
        if (!h) {
            h = color.value.h;
            s = color.value.s;
            b = color.value.b;
        }
        h *= 360;
        var R, G, B, X, C;
        h = (h % 360) / 60;
        C = b * s;
        X = C * (1 - Math.abs(h % 2 - 1));
        R = G = B = b - C;

        h = ~~h;
        R += [C, X, 0, 0, X, C][h];
        G += [X, C, C, X, 0, 0][h];
        B += [0, 0, X, C, C, X][h];
        return {
            r: Math.round(R * 255),
            g: Math.round(G * 255),
            b: Math.round(B * 255),
            a: a || color.value.a
        };
    }
    color.toHex = function (h, s, b, a) {
        var rgb = color.toRGB(h, s, b, a);
        return '#' + ((1 << 24) | (parseInt(rgb.r, 10) << 16) | (parseInt(rgb.g, 10) << 8) | parseInt(rgb.b, 10)).toString(16).substr(1);
    }
    color['rgb'] = function () {
        var rgb = color.toRGB();
        return 'rgb(' + rgb.r + ',' + rgb.g + ',' + rgb.b + ')';
    }
    color['rgba'] = function () {
        var rgb = color.toRGB();
        return 'rgba(' + rgb.r + ',' + rgb.g + ',' + rgb.b + ',' + rgb.a + ')';
    }
    color['hex'] = function () {
        return color.toHex();
    }
    return color;
}])
'use strict';
angular.module('ngQuantum.services.helpers', [])
        .factory('$helpers', ['$injector', '$window', function ($injector, $window) {
            var fn = {};
            
            fn.injectModule = function (name, base) {
                base = base ? base : name;
                var MESSAGE = 'Module ' + base + ' is not available! You either misspelled the module name or forgot to load it. If registering a module ensure that you specify the dependencies as the second argument.';
                var module;
                try {
                    module = $injector.get(name);
                }
                catch (e) {
                    console.error('ngquantum WARNING:', MESSAGE);
                }

                return module;
            }
            fn.isTouch = function () {
                return "createTouch" in $window.document && window.ontouchstart != null;
            }
            var isTouch = fn.isTouch();
            fn.isHtml = function (value) {
                return /<[a-z][\s\S]*>/i.test(value)
            }
            fn.ensureNumber = function (value, defaultval) {
                if (!value) return defaultval || 0;
                if (angular.isString(value)) {
                    return parseFloat(value);
                }
                if (angular.isNumber(value)) {
                    return value;
                }
                else return defaultval || 0;
            }
            fn.parseConstant = function (value) {
                if (/^(true|false|\d+|\-?[0-9]\d+)$/.test(value)) {
                    return eval(value)
                }
                if (angular.isString(value)) {
                    if (value[0] == '[' || (value[0] == '{' && value[1] !== '{{')) {
                        try {
                            return eval(value)
                        }
                        catch (e) {
                            return value.trimStart("'").trimEnd("'")
                        }
                    }
                    return value.trimStart("'").trimEnd("'")
                }
                    
                return value;
            }
            fn.parseOptions = function (attr, options, prefix) {
                if (attr && angular.isDefined(attr.$$element)) {
                    prefix = prefix || 'qo';
                    angular.forEach(attr.$attr, function (value, key) {
                        if (value.length && value.indexOf('qo-') > -1) {
                            var oKey = fn.getOptionKey(key)

                            options[oKey] = fn.parseConstant(attr[key]);
                        }

                    });
                }
                
                return options;
            }
            fn.observeOptions = function (attr, options, callback, prefix) {
                if (attr && angular.isDefined(attr.$$element)) {
                    prefix = prefix || 'qo';
                    if (attr.$$observers)
                        for (var key in attr.$$observers) {
                            if (key.length > 2 && key.startsWith(prefix)) {
                                var oKey = fn.getOptionKey(key, prefix.length);
                                attr.$observe(key, function (newValue, oldValue) {
                                    options[oKey] = fn.parseConstant(newValue);
                                    callback && callback(oKey);
                                });

                            };

                        };
                }
                return options;
            }
            fn.id = function (prefix, random) {
                var id = prefix ? prefix : 'nq-', rd = random || 1000;
                return id + Math.floor((Math.random() * rd) + 1);                      
            }
            fn.getOptionKey = function (key, remove) {
                remove = remove || 2;
                if(key && key.length > remove){
                    var newKey = key.slice(remove);
                    return newKey.charAt(0).toLowerCase() + newKey.slice(1);
                }
                return key
            }
            fn.formatUrl = function (url, params) {
                url = url.trimEnd('/')
                for (var o in params) {
                    params[o] &&(url += '/' + params[o]);
                }
                return url;
            }
            fn.getFieldValue = function (data, field) {
                if (field.indexOf('.') < 0)
                    return data[field]
                else {
                    var fields = field.split('.');
                    var result = data;
                    for (var i = 0; i < fields.length; i++) {
                        if (result)
                            result = result[fields[i]];
                        else
                            break;
                    }
                    return result;
                }
            }

            fn.bindTriggers = function (element, triggers, $master) {
                var array = triggers.split(' ');
                var hasclick = false;
                angular.forEach(array, function (trigger) {
                    if (trigger === 'click') {
                        element.on('click', $master.toggle);
                        hasclick = true;
                        
                    }
                    else if (trigger !== 'manual') {
                        element.on(trigger === 'hover' ? 'mouseenter' : 'focus', $master.enter);
                        element.on(trigger === 'hover' ? 'mouseleave' : 'blur', $master.leave);
                        trigger !== 'hover' && element.on(isTouch ? 'touchstart' : 'mousedown', $master.$onFocusElementMouseDown);
                    }
                });
                return hasclick;
            }
            fn.unBindTriggers = function (element, triggers, $master) {
                var array = triggers.split(' ');
                for (var i = array.length; i--;) {
                    var trigger = array[i];
                    if (trigger === 'click') {
                        element.off('click keyup', $master.toggle);
                    } else if (trigger !== 'manual') {
                        element.off(trigger === 'hover' ? 'mouseenter' : 'focus', $master.enter);
                        element.off(trigger === 'hover' ? 'mouseleave' : 'blur', $master.leave);
                        trigger !== 'hover' && element.off(isTouch ? 'touchstart' : 'mousedown', $master.$onFocusElementMouseDown);
                    }
                }
            }
            fn.stringParsers = [
              {
                  re: /rgba?\(\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*(?:,\s*(\d+(?:\.\d+)?)\s*)?\)/,
                  parse: function (execResult) {
                      return [
                        execResult[1],
                        execResult[2],
                        execResult[3],
                        execResult[4]
                      ];
                  }
              },
              {
                  re: /rgba?\(\s*(\d+(?:\.\d+)?)\%\s*,\s*(\d+(?:\.\d+)?)\%\s*,\s*(\d+(?:\.\d+)?)\%\s*(?:,\s*(\d+(?:\.\d+)?)\s*)?\)/,
                  parse: function (execResult) {
                      return [
                        2.55 * execResult[1],
                        2.55 * execResult[2],
                        2.55 * execResult[3],
                        execResult[4]
                      ];
                  }
              },
              {
                  re: /#([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/,
                  parse: function (execResult) {
                      return [
                        parseInt(execResult[1], 16),
                        parseInt(execResult[2], 16),
                        parseInt(execResult[3], 16)
                      ];
                  }
              },
              {
                  re: /#([a-fA-F0-9])([a-fA-F0-9])([a-fA-F0-9])/,
                  parse: function (execResult) {
                      return [
                        parseInt(execResult[1] + execResult[1], 16),
                        parseInt(execResult[2] + execResult[2], 16),
                        parseInt(execResult[3] + execResult[3], 16)
                      ];
                  }
              }
            ]
            fn.docHeight = function () {
                var body = document.body,
                            html = document.documentElement;

                var height = Math.max(body.scrollHeight, body.offsetHeight,
                                       html.clientHeight, html.scrollHeight, html.offsetHeight);
                return height;
            }
            return fn;
        }
        ])
'use strict';
angular.module('ngQuantum.services.lazy', [])
.provider('$lazyRequest', function () {
    var timeout = this.timeout = 2000;
    this.$get = ['$timeout', '$rootScope', '$http',
      function ($timeout, $rootScope, $http) {
          function Factory(fn, time) {
              time = time || 0;
              if (!$rootScope.$$phase) {
                  $rootScope.$apply(function () {
                      $rootScope.$pendingRequestCount = $rootScope.$pendingRequestCount || 0;
                      $rootScope.$pendingRequestCount++;
                  })
              }
              else {
                  $rootScope.$pendingRequestCount = $rootScope.$pendingRequestCount || 0;
                  $rootScope.$pendingRequestCount++;
              }
              return $timeout(function () {
                  var promise = fn();
                  if (promise && angular.isDefined(promise.then))
                      promise.then(function () {
                          $rootScope.$pendingRequestCount > 0 && $rootScope.$pendingRequestCount--;
                      })
                  return promise;
              }, time);
          }

          return Factory;
      }
    ];
});
'use strict';
angular.module('ngQuantum.services.mouse', [])
        .provider('$mouseConfig', function () {
            this.adjustOldDeltas = true, // see shouldAdjustOldDeltas() below
            this.normalizeOffset = true  // calls getBoundingClientRect for each event
            this.$get = function () {
                return this;
            };
        })
        .factory('$mouse', ['$injector', '$window', '$mouseConfig', function ($injector, $window, $mouseConfig) {
            var isTouch = "createTouch" in $window.document && window.ontouchstart != null;
            var toFix = ['wheel', 'mousewheel', 'DOMMouseScroll', 'MozMousePixelScroll'],
                toBind = ('onwheel' in document || document.documentMode >= 9) ?
                            'wheel' : 'mousewheel DomMouseScroll, MozMousePixelScroll',
                slice = Array.prototype.slice,
                nullLowestDeltaTimeout, lowestDelta;
            var mause = {};


            mause.relativeX = function (event, container) {
                if (event.target == container[0] && event.offsetX) {
                    return event.offsetX
                }
                else {
                    var clinetX = event.pageX || event.clientX || (typeof (event.originalEvent) != 'undefined' ? event.originalEvent.touches[0].clientX : event.touches[0].clientX);
                    return clinetX - container.offset().left;
                }
            }
            mause.relativeY = function (event, container) {
                if (event.target == container[0] && event.offsetY) {
                    return event.offsetY
                }
                else {
                    var clinetY = event.pageY || event.clientY || (typeof (event.originalEvent) != 'undefined' ? event.originalEvent.touches[0].clientY : event.touches[0].clientY);
                    return clinetY - container.offset().top;
                }
            }
            mause.relativePos = function (event, container) {
                return {
                    top: mause.relativeY(event, container),
                    left: mause.relativeX(event, container)
                }
            }
            mause.down = function (element, callback) {
                var eventName = isTouch ? 'touchstart' : 'mousedown';
                return element.on(eventName, callback);
            }
            mause.move = function (element, callback, event) {
                var eventName = ((event && event.touches) || isTouch) ? 'touchmove' : 'mousemove';
                return element.on(eventName, callback);
            }
            mause.up = function (element, callback, event) {
                var eventName = ((event && event.touches) || isTouch) ? 'touchend' : 'mouseup';
                return element.on(eventName, callback);
            }
            
            mause.offDown = function (element, callback) {
                var eventName = isTouch ? 'touchstart' : 'mousedown';
                return callback ? element.off(eventName, callback) : element.off(eventName);
            }
            mause.offMove = function (element, callback) {
                var eventName = isTouch ? 'touchmove' : 'mousemove';
                return callback ? element.off(eventName, callback) : element.off(eventName);
            }
            mause.offUp = function (element, callback) {
                var eventName = isTouch ? 'touchend' : 'mouseup';
                return callback ? element.off(eventName, callback) : element.off(eventName);
            }
            mause.offEnter = function (element, callback) {
                var eventName = isTouch ? 'touchstart' : 'mouseenter';
                return callback ? element.off(eventName, callback) : element.off(eventName);
            }

            mause.onWheel = function (element, callback) {
                if (isTouch)
                    return false;
                element.on(toBind, function (event) {
                    element.data('mousewheel-line-height', getLineHeight(element));
                    element.data('mousewheel-page-height', element.height());
                   
                    return wheelHandler(element, event, callback)
                })
            }
            mause.offWheel = function (element, callback) {
                if (isTouch)
                    return false;
                element.data('mousewheel-line-height', '');
                element.data('mousewheel-page-height', '');
                return callback ? element.off(toBind, callback) : element.off(toBind);
            }
            function wheelHandler(element, orgEvent, callback) {
                var orgEvent = orgEvent || window.event,
                    args = [].slice.call(arguments, 1),
                    delta = 0,
                    deltaX = 0,
                    deltaY = 0,
                    absDelta = 0,
                    offsetX = 0,
                    offsetY = 0;
                var event = angular.extend({}, orgEvent);
                event.type = 'mousewheel';

                event.preventDefault = function () {
                    if (orgEvent.preventDefault) {
                        orgEvent.preventDefault();
                    } else {
                        orgEvent.returnValue = false;
                    }
                };
                event.stopPropagation = function () {
                    if (orgEvent.stopPropagation) {
                        orgEvent.stopPropagation();
                    } else {
                        orgEvent.cancelBubble = false;;
                    }
                };
                if ('detail' in orgEvent) { deltaY = orgEvent.detail * -1; }
                if ('wheelDelta' in orgEvent) { deltaY = orgEvent.wheelDelta; }
                if ('wheelDeltaY' in orgEvent) { deltaY = orgEvent.wheelDeltaY; }
                if ('wheelDeltaX' in orgEvent) { deltaX = orgEvent.wheelDeltaX * -1; }
                if ('axis' in orgEvent && orgEvent.axis === orgEvent.HORIZONTAL_AXIS) {
                    deltaX = deltaY * -1;
                    deltaY = 0;
                }
                delta = deltaY === 0 ? deltaX : deltaY;
                if ('deltaY' in orgEvent) {
                    deltaY = orgEvent.deltaY * -1;
                    delta = deltaY;
                }
                if ('deltaX' in orgEvent) {
                    deltaX = orgEvent.deltaX;
                    if (deltaY === 0) { delta = deltaX * -1; }
                }
                if (deltaY === 0 && deltaX === 0) { return; }
                if (orgEvent.deltaMode === 1) {
                    var lineHeight = element.data()['mousewheel-line-height'];
                    delta *= lineHeight;
                    deltaY *= lineHeight;
                    deltaX *= lineHeight;
                } else if (orgEvent.deltaMode === 2) {
                    var pageHeight = element.data()['mousewheel-page-height'];
                    delta *= pageHeight;
                    deltaY *= pageHeight;
                    deltaX *= pageHeight;
                }
                absDelta = Math.max(Math.abs(deltaY), Math.abs(deltaX));

                if (!lowestDelta || absDelta < lowestDelta) {
                    lowestDelta = absDelta;
                    if (shouldAdjustOldDeltas(orgEvent, absDelta)) {
                        lowestDelta /= 40;
                    }
                }
                if (shouldAdjustOldDeltas(orgEvent, absDelta)) {
                    delta /= 40;
                    deltaX /= 40;
                    deltaY /= 40;
                }
                delta = Math[delta >= 1 ? 'floor' : 'ceil'](delta / lowestDelta);
                deltaX = Math[deltaX >= 1 ? 'floor' : 'ceil'](deltaX / lowestDelta);
                deltaY = Math[deltaY >= 1 ? 'floor' : 'ceil'](deltaY / lowestDelta);
                if ($mouseConfig.normalizeOffset && element[0].getBoundingClientRect) {
                    var boundingRect = element[0].getBoundingClientRect();
                    offsetX = event.clientX - boundingRect.left;
                    offsetY = event.clientY - boundingRect.top;
                }
                event.deltaX = deltaX;
                event.deltaY = deltaY;
                event.deltaFactor = lowestDelta;
                event.offsetX = offsetX;
                event.offsetY = offsetY;
                event.deltaMode = 0;
                args.unshift(event, delta, deltaX, deltaY);
                if (nullLowestDeltaTimeout) { clearTimeout(nullLowestDeltaTimeout); }
                nullLowestDeltaTimeout = setTimeout(nullLowestDelta, 200);
                return callback(event);
            }
            function shouldAdjustOldDeltas(orgEvent, absDelta) {
                return $mouseConfig.adjustOldDeltas && orgEvent.type === 'mousewheel' && absDelta % 120 === 0;
            }
            function nullLowestDelta() {
                lowestDelta = null;
            }
            function getLineHeight(elem) {
                var $parent = elem.offsetParent ? elem.offsetParent() : elem.parent();
                if (!$parent.length) {
                    $parent = angular.element('body');
                }
                return parseInt($parent.css('fontSize'), 10) || parseInt(elem.css('fontSize'), 10) || 16;
            }
            return mause;
        }])
'use strict';
angular.module('ngQuantum.services.parseOptions', [])
        .provider('$parseOptions', function () {
            var defaults = this.defaults = { regexp: /^\s*(.*?)(?:\s+as\s+(.*?))?(?:\s+group\s+by\s+(.*))?\s+for\s+(?:([\$\w][\$\w]*)|(?:\(\s*([\$\w][\$\w]*)\s*,\s*([\$\w][\$\w]*)\s*\)))\s+in\s+(.*?)(?:\s+track\s+by\s+(.*?))?$/ };
            this.$get = [
              '$parse',
              '$q',
              function ($parse, $q) {
                  function ParseOptionsFactory(attr, $element) {
                      var $parseOptions = {};
                      var options = angular.extend({}, defaults);
                      $parseOptions.$values = [];
                      var match, displayFn, valueName, keyName, groupByFn, valueFn, valuesFn;
                      $parseOptions.init = function () {
                          $parseOptions.$match = match = attr.match(options.regexp);
                          displayFn = $parse(match[2] || match[1]), valueName = match[4] || match[6], keyName = match[5], groupByFn = $parse(match[3] || ''), valueFn = $parse(match[2] ? match[1] : valueName), valuesFn = $parse(match[7]);

                      };
                      $parseOptions.valuesFn = function (scope, controller) {
                          return $q.when(valuesFn(scope, controller)).then(function (values) {
                              $parseOptions.$values = values ? parseValues(values) : {};
                              return $parseOptions.$values;
                          });
                      };
                      $parseOptions.parseInit = function () {
                        
                          $parseOptions.$values = parseElement($element)
                      }
                      $parseOptions.valuesParse = function (elem) {
                          return $q.when(elem).then(function (el) {
                              $parseOptions.$values = parseElement(el) || [];
                              return $parseOptions.$values;
                          });
                      };
                      function parseValues(values) {
                          return values.map(function (match, index) {
                              var locals = {}, label, value, group;
                              locals[valueName] = match;
                              label = displayFn(locals);
                              value = valueFn(locals) || label;
                              group = groupByFn(locals);
                              return {
                                  label: label,
                                  value: value,
                                  group: group ? { label: group } : undefined,
                                  disabled: match.disabled
                              };
                          });
                      }

                      function parseElement(element) {
                          var array = [];

                          angular.forEach(element.children(), function (value, key) {
                              if (angular.element(value).is("option")) {
                                  array.push(optionToData(angular.element(value)))
                              }
                              else if (angular.element(value).is("optgroup")) {
                                  var group = optionGroupToData(angular.element(value));
                                  angular.forEach(angular.element(value).children(), function (gval, gkey) {
                                      array.push(optionToData(angular.element(gval), group))
                                  })

                              }
                              

                          })
                          return array;
                      }

                      function optionToData(element, group) {
                          return {
                              value: element.prop("value"),
                              label: element.text(),
                              group: group,
                              disabled: element.prop("disabled") || group && group.disabled
                          };
                      }
                     
                      function optionGroupToData(element) {
                          return {
                              label: element.attr("label"),
                              disabled: element.prop("disabled")
                          };
                      }
                    
                      if ($element)
                          $parseOptions.parseInit();
                      else
                          $parseOptions.init();
                      return $parseOptions;
                  }
                  return ParseOptionsFactory;
              }
            ];
        });
'use strict';
angular.module('ngQuantum.services.placement', ['ngQuantum.services.helpers'])
        .factory('$placement', ['$helpers', function ($helpers) {
            var fn = {};
            fn.applyPlacement = function (element, $target, options) {
                if (!element || !$target)
                    return;
                var placement = options.placement,
                    position = getPosition(element, options);
                
                options.originalPlacement = placement
                var autoToken = /\s?auto?\s?/i
                var autoPlace = autoToken.test(placement)
                if (autoPlace) placement = placement.replace(autoToken, '') || 'top'

                if (autoPlace) {
                    placement = getPlacement(element, placement, position, options.container)
                    $target.removeClass(options.originalPlacement).addClass(placement)
                }
                var width = $target.outerWidth(true),
                    height = $target.outerHeight(true);
                var offset = getCalculatedOffset(placement, position, width, height);
                
                offset.top = offset.top + $helpers.ensureNumber(options.offsetTop)
                offset.left = offset.left + $helpers.ensureNumber(options.offsetLeft)
                var marginTop = parseInt($target.css('margin-top'), 10)
                var marginLeft = parseInt($target.css('margin-left'), 10)
                if (isNaN(marginTop)) marginTop = 0;
                if (isNaN(marginLeft)) marginLeft = 0;
                
                offset.top = offset.top + marginTop;
                offset.left = offset.left + marginLeft;

                if (options.insideFixed) {
                    $target.css(offset);
                } else
                    $target.offset(offset);
                fn.ensurePosition($target, element, options)
                return options;
            }
            fn.verticalPlacement = function ($target, options) {
                var windowHeght = window.screen.height || 0;
                var targetHeight = $target.height() || 0;
                var diff = windowHeght - targetHeight - 10;
                if (diff > 0) {
                    var top = 0;
                    switch (options.placement) {
                        case 'center':
                            top = diff / 2
                            break;
                        case 'bottom':
                            top = diff
                            break;
                        case 'near-top':
                            top = diff / 3
                            break;
                        case 'near-bottom':
                            top = (diff / 3) * 2
                            break;
                        default:
                            top = 0
                    }
                    $target.css('top', top);
                }

            }
            fn.ensurePosition = function ($target, element, options) {
                var offset = options.insideFixed ? $target.position() : $target.offset(), ww = window.screen.width, dh = $helpers.docHeight(),
                    tw = $target.width(), th = $target.height(), eh = element.height(), eo = options.insideFixed ? element.position() : element.offset(), classList = $target.attr('class');
                if (offset.left < 0) {
                    $target.css('left', 0);
                    $target.attr('class', classList.replace('right', 'left'));
                }
                else if (offset.left >  (ww - tw)) {
                    $target.css('left', (element.width() - tw));
                    $target.attr('class', classList.replace('left', 'right'));
                }
                if (offset.top < 0) {
                    $target.css('top', eo.top);
                    $target.attr('class', classList.replace('bottom', 'top'));
                }
                else if (offset.top > (dh - th)) {
                    $target.css('left', (eo.top - th));
                    $target.attr('class', classList.replace('top', 'bottom'));
                }
                    
                
            }
            fn.replaceArrow = function ($target, delta, dimension, position) {
                $target.find('.arrow').css(position, delta ? (50 * (1 - delta / dimension) + "%") : '')
            }
            function getPosition(element, options) {
                var el = element[0];
                var clipRect = (typeof el.getBoundingClientRect == 'function') ? el.getBoundingClientRect() : {
                    width: el.offsetWidth
                   , height: el.offsetHeight
                };
                var rectObj = {};
                for (var o in clipRect) {
                    rectObj[o] = clipRect[o];
                }
                var offset = options.insideFixed ? element.position() : element.offset();
                var result = angular.extend({}, rectObj, offset);
               return result;
            }
            function getCalculatedOffset(placement, position, actualWidth, actualHeight) {
                var offset;
                var split = placement.split('-');
                switch (split[0]) {
                    case 'right':
                        offset = {
                            top: position.top + (position.height / 2) - (actualHeight / 2),
                            left: position.left + position.width
                        };
                        break;
                    case 'bottom':
                        offset = {
                            top: position.top + position.height,
                            left: position.left + (position.width / 2) - (actualWidth / 2)
                        };
                        break;
                    case 'left':
                        offset = {
                            top: position.top + (position.height / 2) - (actualHeight / 2),
                            left: position.left - actualWidth
                        };
                        break;
                    default:
                        
                        offset = {
                            top: position.top - actualHeight,
                            left: position.left + (position.width / 2) - (actualWidth / 2)
                        };
                        break;
                }
                if (!split[1]) {
                    return offset;
                }
                if (split[0] === 'top' || split[0] === 'bottom') {
                    switch (split[1]) {
                        case 'left':
                            offset.left = position.left;
                            break;
                        case 'right':
                            offset.left = position.left + position.width - actualWidth;
                    }
                } else if (split[0] === 'left' || split[0] === 'right') {
                    switch (split[1]) {
                        case 'top':
                            offset.top = position.top - actualHeight + position.height;
                            break;
                        case 'bottom':
                            offset.top = position.top
                    }
                }
                return offset;
            }
            function getPlacement(element, placement, position, container) {
                var actualWidth = element[0].offsetWidth
                var actualHeight = element[0].offsetHeight
                var $parent = element.parent()
                if (container)
                    container == container == 'body' ? window : angular.element(container)[0];
                var docScroll = document.documentElement.scrollTop || document.body.scrollTop
                var parentWidth = container ? container.innerWidth : $parent.outerWidth()
                var parentHeight = container ? container.innerHeight : $parent.outerHeight()
                var parentLeft = container ? 0 : $parent.offset().left

                placement = placement == 'bottom' && position.top + position.height + actualHeight - docScroll > parentHeight ? 'top' :
                            placement == 'top' && position.top - docScroll - actualHeight < 0 ? 'bottom' :
                            placement == 'right' && position.right + actualWidth > parentWidth ? 'left' :
                            placement == 'left' && position.left - actualWidth < parentLeft ? 'right' :
                            placement
                return placement;
            }

            return fn;
        }
        ]);

+function (window, angular, undefined) {
    'use strict';
    angular.module('ngQuantum.services', [
        'ngQuantum.services.lazy',
        'ngQuantum.services.mouse',
        'ngQuantum.services.helpers',
        'ngQuantum.services.parseOptions',
        'ngQuantum.services.templateHelper',
        'ngQuantum.services.placement',
        'ngQuantum.services.color'
    ])

}(window, window.angular);
'use strict';
angular.module('ngQuantum.services.templateHelper', []).factory('templateHelper', [
      '$http',
      '$q',
      '$templateCache',
      '$timeout',
      function ($http, $q, $templateCache, $timeout) {
          var fn = {};
          fn.fetchTemplate = function (template) {
              return $q.when($templateCache.get(template) || $http.get(template)).then(function (res) {
                  if (angular.isObject(res)) {
                      return res.data;
                  }
                  return res;
              });
          }
          fn.fetchContentTemplate = function ($object) {
              return $object.$promise.then(function (template) {
                  var tm = angular.element(template);
                  var tel = tm.find('[ng-bind="content"], [ng-bind-html="content"]');
                  var ct = $object.$options.contentTemplate;
                  if ((angular.isString(ct) && ct.indexOf('.html') > -1)) {
                      return fn.fetchTemplate($object.$options.contentTemplate).then(function (contentTemplate) {
                          if (tel.length) {
                              tel.removeAttr('ng-bind').removeAttr('ng-bind-html').html(contentTemplate)
                              return tm;
                          }
                          else
                              return contentTemplate
                      });
                  }
                  return template;

              });
          }
          fn.fetchContent = function ($object) {
              return $q.when($object).then(function (template) {
                  return template;
              });
          }
          return fn;
      }
    ]);
+function(){'use strict';
angular.module('ngQuantum.alert', ['ngQuantum.popMaster', 'ngQuantum.services.helpers'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('alert/alert.tpl.html',
          "<div class=\"alert alert-dismissable\" tabindex=\"-1\" ng-class=\"alertType\"><div class=\"alert-inner\"><div class=\"alert-bg\" ng-class=\"alertType\"></div><a role=\"button\" tabindex=\"0\" class=\"close\" ng-click=\"$hide()\"><i ng-class=\"$closeIcon\"></i></a> <strong class=\"alert-title\" ng-if=\"title\" ng-bind=\"title\"></strong><span  ng-if=\"title\" ng-bind-html=\"content\"></span><div ng-if=\"!title\" ng-bind-html=\"content\"></div></div></div>"
        );

    }])
    .provider('$alert', function () {
        var defaults = this.defaults = {
            effect: 'fade-in',
            typeClass: 'alert',
            prefixEvent: 'alert',
            placement: 'top-right',
            fireEmit: true,
            template: 'alert/alert.tpl.html',
            container: false,
            directive: 'nqAlert',
            instanceName: 'alert',
            backdrop: false, //NOT USED
            displayReflow: true,
            clearExists: false,
            keyboard: true,
            trigger:'click',
            show: true,
            html:true,
            independent: true,
            preventReplace: true,
            alertType: 'info',
            duration: 3000,
            autoDestroy: false,
            onHide: false,
            closeIcon: 'fic fu-cross'
        };
        this.$get = ['$timeout', '$rootScope', '$popMaster', '$compile', '$helpers', '$sce', '$parse',
          function ($timeout, $rootScope, $popMaster, $compile, $helpers, $sce, $parse) {
              function AlertFactory(config, title, alertType, placement) {
                  var $alert = {}, attr;
                  if (angular.isString(config)) {
                      config = {
                          content: config,
                          title: title,
                          alertType: alertType || defaults.alertType,
                          placement: placement || defaults.placement
                      }
                  }
                  if (!config.$scope) {
                      config.autoDestroy = true;
                  }
                  angular.isObject(title) && (attr = title)
                  attr && (config = $helpers.parseOptions(attr, config))
                  var options = angular.extend({}, defaults, config);
                  if (options.containerSelf)
                      options.container = options.containerSelf;
                  var container
                  if (!options.container)
                      getContainer();
                  $alert = $popMaster(null, options);
                  var scope = $alert.$scope;
                  if (attr)
                      options = $alert.$options = $helpers.observeOptions(attr, $alert.$options);
                  else {
                      options.content && (scope.content = options.content)
                      options.title && (scope.title = options.title)

                  }
                  if (attr && attr.onHide)
                      options.onHide = $parse(attr.onHide);
                  var show = $alert.show;
                  $alert.show = function () {
                      scope.$closeIcon = options.closeIcon;
                      options.alertType && (scope.alertType = 'alert-' + options.alertType)
                      container && container.show()
                      var promise = show();
                      $compile($alert.$target)(scope);
                      if (options.duration)
                          $timeout(function () {
                              $alert &&  $alert.hide();
                          }, $helpers.ensureNumber(options.duration, 3000));
                      return promise;
                  };
                  var hide = $alert.hide;
                  $alert.hide = function () {
                      var promise = hide();
                      promise && promise.then(function () {
                          options.onHide && options.onHide(scope);
                          if (container) {
                              var chlids = container.children();
                              if (!chlids || chlids.length < 1) {
                                  container.hide();
                              }
                          }
                          options.autoDestroy && $alert && $alert.destroy();
                      })
                      return promise;
                  };
                  function getContainer() {
                      var placement = '';
                      options.placement && (placement = '.' + options.placement)
                      container = angular.element('body').find('.alert-container' + placement);
                      if (!container || container.length < 1) {
                          container = angular.element('<div class="alert-container ' + options.placement + '"></div>');
                          container.prependTo('body')
                      }
                      options.container = container;
                  }
                  
                  if (attr) {
                      angular.forEach(['title', 'content'], function (key) {
                          var akey = 'qs' + key.capitaliseFirstLetter();
                          attr[akey] && (scope[key] = $sce.trustAsHtml(attr[akey]));
                          attr.$$observers && attr.$$observers[akey] && attr.$observe(akey, function (newValue, oldValue) {
                              scope[key] = $sce.trustAsHtml(newValue);
                          });
                      });
                      if (attr && angular.isDefined(options.directive)) {
                          attr[options.directive] && options.$scope.$watch(attr[options.directive], function (newValue, oldValue) {
                              if (angular.isObject(newValue)) {
                                  angular.extend(scope, newValue);
                              } else {
                                  scope.content = newValue;
                              }
                          }, true);
                      }
                  }
                  scope.$on('$destroy', function () {
                      $alert && !$alert.isDestroyed && $alert.destroy();
                      $alert = null;
                  });
                  return $alert;
              }
              return AlertFactory;
          }
        ];
    })
    .directive("nqAlert", ['$alert',
        function ($alert) {
            return {
                restrict: 'EAC',
                scope: true,
                link: function postLink(scope, element, attr, transclusion) {
                    var firstLoad;
                    var options = {
                        $scope: scope
                    };
                    options.uniqueId = attr.qoUniqueId || attr.id || options.$scope.$id;
                    !angular.isDefined(attr.qsContent) && (scope.content = element.html(), element.html(''))
                    if (angular.isDefined(attr.qoContainer) && attr.qoContainer == 'self') {
                        options.containerSelf = element;
                    }
                    !attr.qoShow && (options.show = false);

                    var alert = $alert(options, attr);
                    if (angular.isDefined(attr.qsShowOn)) {
                        scope.$watch(attr.qsShowOn, function (value) {
                            (firstLoad || value) && alert.toggle();
                            firstLoad = true;
                        })
                    }
                    if (!angular.isDefined(attr.qoContainer) || !attr.qoContainer == 'self') {
                        element.on('click', function () {
                            alert.toggle();
                        })
                    }

                }
            };
        }]);
 }();
(function (window, angular, undefined) {
'use strict';
var asideoptions = {
    effect: 'slide-left',
    speed: 'fastest',
    side: 'left',
    opened: false,
    pinned: false,
    collapsed: false,
    collapsible: false,
    pinnable: false,
    pinnedScreenSize: 1300,
    collapsedScreenSize: 991,
    closedScreenSize: 767,
    position: 'fixed',   // can be fixed|relative|absolute
    offCanvas: 'mobile', // can be all|desktop|touches or false,
    offCanvasBody: 'body',
    container: 'self',
    theme: false,
    backDrop: false,
    topOffset: 50,
    scrollOffsetTop:false, //if you navbar is fixed set this false
    bottomOffset: 0,
    width:false,
    enlargeHover: false, //ngSwipeLeft and ngSwipeRight can be used for touch devices
};
    angular.module('ngQuantum.aside', ['ngQuantum.services.helpers'])
    .provider('$aside', function () {
        var defaults = this.defaults = asideoptions;
        
        this.$get = ['$rootScope', '$animate', '$timeout', '$window',
        function ($rootScope, $animate, $timeout, $window) {
            var isTouch = "createTouch" in $window.document && window.ontouchstart != null;
              function Factory(element, config, attr) {
                  var $aside = {}
                  var options = $aside.$options = angular.extend({}, defaults, config);
                  var scope = options.$scope || $rootScope.$new();
                  var body = angular.element(options.offCanvasBody), $container, applyBody = options.pinnable || options.collapsible;
                  var classes = ['aside-pinned', 'aside-collapsed', 'aside-opened', 'aside-closed'], backDrop;
                  

                  if (attr && attr.$$observers) {
                      angular.forEach(attr.$$observers, function (value, key) {
                          if (angular.isDefined(options[key])) {
                              attr.$observe(key, function (newValue, oldValue) {
                                  if (newValue != options[key]) {
                                      changeOptions(key, newValue)
                                      options[key] = newValue;
                                  }
                                      
                              });
                          }

                      });
                  }
                      
                  $aside.toggle = function () {
                      if ($aside.$isOpen) {
                          $aside.close()
                      }
                      else {
                          $aside.open()
                      }
                      scope.$$phase || scope.$digest();
                  };
                  $aside.toggleCollapse = function (collapse) {
                      if (!options.collapsible)
                          return;
                      if ($aside.$collapsed) {
                          if (collapse)
                              return;
                          element.removeClass('aside-collapsed');
                          applyBody && body.removeClass(options.side + '-aside-collapsed');
                          $timeout(function () {
                              $aside.$collapsed = false;
                          }, 0)
                          
                          if (options.enlargeHover && !isTouch) {
                              element.off('mouseenter mouseleave')
                              $aside.$isOpen && element.on('mouseleave', function () {
                                  $aside.toggleCollapse();
                              })
                          }
                      }
                      else {
                          if (!$aside.$isOpen || collapse == false)
                              return;
                          if (options.enlargeHover && !isTouch) {
                              element.off('mouseenter mouseleave')
                              element.on('mouseenter', function () {
                                  $aside.toggleCollapse();
                              })
                          }
                          element.addClass('aside-collapsed');
                          applyBody && body.addClass(options.side + '-aside-collapsed');
                          $timeout(function () {
                              $aside.$collapsed = true;
                          }, 0)
                          
                      }
                  };
                  $aside.close = function () {
                      if ($aside.$isOpen == false)
                          return;
                      
                      if (options.effect) {
                          element.off('mouseenter mouseleave')
                            element.removeClass('aside-opened');
                            element.show();
                            element.addClass(options.speed);
                            $animate.removeClass(element, options.effect).then(function () {
                                element.hide();
                                element.addClass('aside-closed');
                                element.removeClass(options.speed);
                                element.removeClass('ng-animate');
                            })
                      } else {
                          element.removeClass('aside-opened');
                          element.addClass('aside-closed');
                          element.removeClass(options.speed);
                          element.removeClass(options.effect);
                      }
                      clearStyle();
                      $timeout(function () {
                          $aside.$isOpen = false;
                      }, 0)
                      
                      backDrop && backDrop.detach();
                  };
                  $aside.open = function () {
                      if ($aside.$isOpen)
                          return;
                      clearStyle();
                      element.removeClass('aside-closed');
                      $container && $container.append(element);
                      if (options.effect) {
                          element.show();
                          element.addClass(options.speed);
                          element.animationEnd(function () {
                              element.removeClass(options.speed);
                              element.removeClass('ng-animate');
                          });
                          $animate.addClass(element, options.effect);
                          element.addClass('aside-opened');

                      } else
                          element.addClass('aside-opened');
                      applyBody && body.addClass(options.side + '-aside-opened');

                      $aside.$isOpen = true;
                      $aside.togglePin($aside.$pinned || false)
                      $aside.toggleCollapse($aside.$collapsed || false);
                      backDrop && element.after(backDrop);
                      $timeout(function () {
                          $aside.$collapsed = false;
                          $aside.$isOpen = true;
                      }, 0)
                  };
                  $aside.togglePin = function (pin) {
                      if (!options.pinnable)
                          return;
                      if ($aside.$pinned) {
                          if (pin) {
                              if (!$aside.$isOpen) {
                                  $aside.open()
                                  return;
                              }
                              element.addClass('aside-pinned');
                              applyBody && body.addClass(options.side + '-aside-pinned');
                              $aside.$pinned = true;
                              return;
                          };
                          element.removeClass('aside-pinned');
                          applyBody && body.removeClass(options.side + '-aside-pinned');
                          $aside.$pinned = false;
                      }
                      else {
                          if (!$aside.$isOpen || pin == false)
                              return;
                          element.addClass('aside-pinned');
                          applyBody && body.addClass(options.side + '-aside-pinned');
                          $aside.$pinned = true;
                      }
                      if (!options.enlargeHover || options.enlargeHover == 'false')
                          element.off('mouseenter mouseleave');
                      else {
                          element.off('mouseenter mouseleave')
                          element.on('mouseenter', function () {
                              $aside.toggleCollapse();
                          })
                      }
                  };
                  function refresh() {
                      element.addClass('aside')
                      clearStyle();
                      if (!options.opened) {
                          $aside.close();
                      } else {
                          $aside.open();
                          options.pinned && $aside.togglePin(true)
                          options.collapsed && $aside.toggleCollapse(true);
                      }
                      applyOptions();
                      addBackdrop();
                      addToContainer();
                      clearTheme(options.theme)
                      clearPosition(options.position)
                      clearOffCanvas(options.offCanvas)
                      checkSizes();
                  };
                  window.addResizeEvent(function () {
                      $timeout(function () {
                          var newVal = $window.innerWidth;
                          checkSizes(newVal);
                      }, 0)
                  })
                  function clearStyle() {
                      applyBody && body.removeClasses([options.side + '-aside-opened', options.side + '-aside-collapsed', options.side + '-aside-pinned']);
                      element && element.removeClasses(classes);
                  }
                  function checkSizes(newVal) {
                      newVal = newVal || $window.innerWidth;
                      if (newVal == $aside.windowWidth)
                          return;
                      if (options.closedScreenSize && options.closedScreenSize >= newVal) {
                          $aside.close();
                      } else {
                          if (options.collapsedScreenSize && options.collapsedScreenSize >= newVal) {
                              $aside.toggleCollapse(true);
                          }
                          if (options.pinnedScreenSize && options.pinnedScreenSize <= newVal) {
                              $aside.togglePin(true);
                          }
                      }
                      $aside.windowWidth = newVal;
                  }
                  function addBackdrop() {
                      if (backDrop) {
                          backDrop.off();
                          backDrop.remove();
                      }
                      if (!options.backDrop)
                          return;
                      backDrop = angular.element('<div class="aside-overlay"></div>')
                                .on('click', function () {
                                    $aside ? $aside.close() : backDrop.remove();
                                });
                  }
                  function changeOptions(key, value) {
                      switch(key){
                          case "theme":
                              clearTheme(value)
                              break;
                          case "position":
                              clearPosition(value)
                              break;
                          case "offCanvas":
                              clearOffCanvas(value)
                              break;
                          case "topOffset":
                              element.css('top', value);
                              break;
                          case "bottomOffset":
                              element.css('bottom', value);
                              break;
                          case "backDrop":
                              addBackdrop();
                              break;
                          case "side":
                              $aside.close();
                              $aside.open();
                              break;
                      }

                  }
                  function applyOptions() {
                      element.addClass('aside-'+ options.side);
                      element.css('top', options.topOffset && options.topOffset || 0);
                      element.css('bottom', options.bottomOffset && options.bottomOffset || 0);
                      if (options.width)
                          element.css('width', options.width);
                      if (options.collapsible)
                          applyBody && body.addClass(options.side + '-aside-collapsible');
                  }
                  function addToContainer() {
                      if (options.container && options.container !== 'self') {
                          var cont = angular.element(options.container);
                          if (cont.length) {
                              $container = angular.element(cont[0]);
                              $container.append(element);
                          }
                      }
                  }
                  function clearPosition(value) {
                      if (options.position) {
                          element.removeClass('aside-' + options.position)
                          applyBody && body.removeClass(options.side + '-aside-' + options.position)
                      }
                      if (value) {
                          element.addClass('aside-' + value)
                          applyBody && body.addClass(options.side + '-aside-' + value)
                      }
                  }
                  function clearOffCanvas(value) {
                      if (options.offCanvas) {
                          element.removeClass('off-canvas-' + options.offCanvas)
                          applyBody && body.removeClass(options.side + '-off-canvas-' + options.offCanvas)
                      }
                      if (value) {
                          element.addClass('off-canvas-' + value)
                          applyBody && body.addClass(options.side + '-off-canvas-' + value)
                      }
                  }
                  function clearTheme(value) {
                      options.theme && element.removeClass('aside-' + options.theme)
                      value && element.addClass('aside-' + value);
                  }
                  refresh();
                  scope.$$postDigest(function () {
                      scope.$aside = $aside
                  });
                  angular.element(window).on('scroll', function (evt) {
                      if(options.scrollOffsetTop && options.topOffset > 0){
                          var top = angular.element(window).scrollTop()
                          if(top > options.topOffset)
                              element.css('top', 0)
                          else if(top == 0)
                              element.css('top', options.topOffset)
                          else
                              element.css('top', options.topOffset - top)
                      }
                      
                  })
                  scope.$on('$destroy', function() {
                      if (backDrop) {
                          backDrop.off();
                          backDrop.remove();
                      }
                      $aside && ($aside == null);
                      element && element.off();
                      clearStyle();
                  });
                  angular.element(document).ready(function () {
                      setTimeout(function () {
                          if (element.height() > window.innerHeight) {
                              element.css('position', 'relative')
                              setTimeout(function () {
                                  element.css('position', '')
                              }, 100)
                          }
                              
                      }, 10)
                  })
                  return $aside;
              }
              return Factory;
          }
        ];
    })
    .directive("nqAside", ["$aside", '$helpers', function ($aside, $helpers) {
        return {
            restrict: "AC",
            scope: true,
            link: function postLink(scope, element, attr, controller) {
                var options = {
                    $scope: scope,
                    id : attr.id || 'aside-' + scope.$id
                }
                angular.forEach(asideoptions, function (val, key) {
                    if (angular.isDefined(attr[key]) && attr[key].indexOf('{{') < 0)
                        options[key] = $helpers.parseConstant(attr[key]);
                        
                });
                var header = element.find('.aside-header');
                if (header.length) {
                    var hh = header.outerHeight(true);
                    element.css('padding-top', hh), header.css('margin-top', -hh)
                }
                var footer = element.find('.aside-footer')
                if (footer.length) {
                    var fh = footer.outerHeight(true);
                    element.css('padding-bottom', fh);
                }
                var aside = new $aside(element, options, attr);
                var asideName = attr.nqAside;
                if (asideName)
                    scope.$parent[asideName] = aside;
            }
        };
    }])
    .directive('asideToggle', ['$timeout', function ($timeout) {
        return {
            restrict: 'A',
            link: function postLink(scope, element, attr) {
                element.on('click', function () {
                    var asideEl = attr.asideToggle ? angular.element(attr.asideToggle) : false;
                    if (asideEl.length) {
                        var aScope = asideEl.scope();
                        if (aScope && aScope.$aside) {
                            $timeout(function () {
                                aScope.$aside.toggle();
                            }, 0);
                        }
                            
                        
                    }

                })
            }
        };
    }])
})(window, window.angular);
+function (window, angular, undefined) {
'use strict';
    var nqButtonsApp = angular.module('ngQuantum.button', ['ngAnimate', 'ngQuantum.services.helpers'])
        .provider('$button', function () {
            var defaults = this.defaults = {
                activeClass: 'active',
                toggleEvent: 'click',
                activeIcon:'',
            };
            this.$get = function () {
                return { defaults: defaults };
            };
        });
        angular.forEach(['CheckboxGroup', 'RadioGroup'], function (directive) {
            nqButtonsApp.directive('nq' + directive, function () {
                return {
                    restrict: 'A',
                    require: 'ngModel',
                    compile: function postLink(element, attr) {
                        var dirType = directive == 'CheckboxGroup' ? 'checkbox' : 'radio'
                        element.attr('data-toggle', 'buttons');
                        element.removeAttr('ng-model');
                        var children = element.find('input[type="' + dirType + '"]');
                        var trueVal, falseVal
                        if (dirType == 'checkbox')
                            trueVal = attr.trueValue, falseVal = attr.falseValue;

                        angular.forEach(children, function (child) {
                            var childEl = angular.element(child);
                            childEl.attr('nq-' + dirType + '-button', '');
                            if (dirType == 'checkbox') {
                                childEl.attr('ng-model', attr.ngModel + '.' + childEl.attr('value'));
                                (!childEl.attr('ng-true-value') && trueVal) && childEl.attr('ng-true-value', trueVal);
                                (!childEl.attr('ng-false-value') && falseVal) && childEl.attr('ng-false-value', falseVal)
                            }
                            else
                                childEl.attr('ng-model', attr.ngModel);
                            childEl.attr('name', attr.ngModel);
                            attr.showTick && childEl.attr('show-tick', attr.showTick)
                            if (attr.ngChange) {
                                if (angular.isDefined(childEl.attr('ng-change'))) {
                                    childEl.attr('ng-change', childEl.attr('ng-change') + ';' +attr.ngChange);
                                }
                                else
                                    childEl.attr('ng-change', attr.ngChange);
                            }

                        });
                    }
                };
            });
        })
        angular.forEach(['Checkbox', 'Radio', 'Toggle'], function (directive) {
            nqButtonsApp.directive('nq' + directive + 'Button', ['$button', '$helpers', function ($button, $helpers) {
                return {
                    restrict: 'A',
                    require: 'ngModel',
                    link: function postLink(scope, element, attr, controller) {
                        var options = $button.defaults;
                        directive = directive.toLowerCase();
                        directive == 'toggle' && (directive = 'checkbox')
                        var isInput = attr.type === directive;
                        var activeElement = isInput ? element.parent() : element;
                        var trueValue, falseValue;
                        if (directive == 'checkbox') {
                            trueValue = angular.isDefined(attr.ngTrueValue) ? $helpers.parseConstant(attr.ngTrueValue) : true;
                            falseValue = angular.isDefined(attr.ngFalseValue) ? $helpers.parseConstant(attr.ngFalseValue) : false;
                        }
                        else {
                            trueValue = attr.ngValue ? scope.$eval(attr.ngValue) : $helpers.parseConstant(attr.value);
                        }

                        if ($helpers.parseConstant(attr.showTick) == true) {
                            activeElement.addClass('tick-right')
                        }
                        attr.showTick == 'left' && activeElement.addClass('tick-left')
                        angular.isDefined(attr.checked) && controller.$setViewValue(trueValue);

                        scope.$watch(attr.ngModel, function (newValue, oldValue) {
                            var isActive = angular.equals($helpers.parseConstant(controller.$modelValue), trueValue);
                            !isActive && element.removeAttr('checked');
                            activeElement.toggleClass(options.activeClass, isActive);
                        });
                        if (!isInput) {
                            element.bind(options.toggleEvent, function () {
                                var viewValue = directive == 'radio' ? trueValue : controller.$modelValue ? $helpers.parseConstant(controller.$modelValue) == trueValue ? falseValue : trueValue : trueValue;
                                controller.$setViewValue(viewValue);
                                scope.$apply();
                            });
                        }
                    }
                };
            }])
        });
 }(window, window.angular);
+function (window, angular, undefined) {
'use strict';
    angular.module('ngQuantum.carousel', ['ngQuantum.services.helpers'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('carousel/carousel.tpl.html',
                 '<div class="carousel" ng-style="{width:$outerWidth}">'
                   + '<ol class="carousel-indicators">'
                       + '<li ng-repeat="item in items"  indicator-transclude="item" ng-class="{active: item.active}" ng-click="item.select($index)">'
                           + '<span class="indicator-no">{{$index + 1}}</span>'
                       + '</li>'
                   + '</ol>'
                   + '<div class="carousel-inner" ng-transclude ng-style="{height:$innerHeight}"></div>'
                   + '<div class="carousel-control left"  ng-click="$prev()">'
                        + '<span class="icon-prev"></span>'
                    + '</div>'
                    + '<div class="carousel-control right" ng-click="$next()">'
                        + '<span class="icon-next"></span>'
                    + '</div>'
               + '</div>'
        );
    }])
    .provider('$carousel', function () {
        var defaults = this.defaults = {
            effect: 'slide-left-right',
            type: 'carousel',
            speed: 'fastest',
            prefixEvent: 'carousel',
            directive: 'nqCarousel',
            instanceName: 'carousel',
            keyboard: true,
            hoverStop: true,
            showIndicator: true,
            showPrevNext: true,
            showPause: true,
            showPlay: true,
            autoPlay: true,
            outerWidth: '650px',
            innerHeight: '405px',
            interval: 5000
        };
        this.$get = ['$timeout', '$interval', '$filter', '$compile', '$sce', '$animate',
          function ($timeout, $interval, $filter, $compile, $sce, $animate) {
              function CarouselFactory($element, $scope, config) {

                  var $carousel = {},
                  options = $carousel.$options = angular.extend({}, defaults, config),
                  items = $carousel.items = $scope.items = [];
                  var lastIndex = $carousel.$lastIndex = 0;
                  var stopFunc;
                  angular.forEach(['next', 'prev', 'play', 'pause'], function (value) {
                      $scope['$' + value] = function (evt) {
                          $carousel[value](evt);
                      }
                  })
                  angular.forEach(['outerWidth', 'innerHeight'], function (value) {
                      $scope['$' + value] = options[value];
                  })
                  if ($element.hasClass('thumb-navigation') || $element.hasClass('number-navigation')) {
                      $carousel.$watchIndicator = true;
                  }
                  $carousel.init = function () {
                      if (options.autoPlay) {
                          $carousel.play()
                          hoverStop();
                      }
                      $timeout(function () {
                          if (parseInt($scope.$outerWidth) > $element.width()) {
                              $scope.$innerHeight = ((parseInt($scope.$innerHeight) / parseInt($scope.$outerWidth)) * $element.width()) + 'px';
                          }
                      }, 800)
                  };
                  $carousel.select = function (index) {
                      var selectedItem = items[index];
                      angular.forEach(items, function (item) {
                          if (item.active && item !== selectedItem) {
                              item.active = false;
                              item.activeClasses = '';
                          }
                      });
                      if (selectedItem) {
                          selectedItem.active = true;
                          lastIndex = $carousel.$lastIndex = index;
                      }
                      
                  };
                  $carousel.pause = function () {
                      $interval.cancel(stopFunc)
                  };
                  $carousel.play = function () {
                      stopFunc = $interval($carousel.next, options.interval)
                  };
                  $carousel.next = function (evt) {
                      var i = lastIndex < items.length - 1 ? lastIndex + 1 : 0
                      $carousel.select(i);
                  };
                  $carousel.prev = function () {
                      var i = lastIndex > 0 ? lastIndex - 1 : items.length - 1
                      $carousel.select(i);
                  };
                  $carousel.addItem = function (item) {
                      items.push(item);
                      if (items.length === 1) {
                          item.active = true;
                      } else if (item.active) {
                          $carousel.select(items.indexOf(item));
                      }
                  };
                  $carousel.removeItem = function (item) {
                      var index = items.indexOf(item);
                      if (item.active && items.length > 1) {
                          var newActiveIndex = index == items.length - 1 ? index - 1 : index + 1;
                          $carousel.select(newActiveIndex);
                      }
                      items.splice(index, 1);
                  };
                  $carousel.init();

                  function hoverStop() {
                      if (options.hoverStop) {
                          $element.on('mouseenter', function () {
                              $carousel.pause();
                          })
                          $element.on('mouseleave', function () {
                              $carousel.play();
                          })
                      }
                  }

                  return $carousel;
              }
              return CarouselFactory;
          }
        ];
    })
    .directive('nqCarousel', ['$carousel', '$helpers', function ($carousel, $helpers) {
        return {
            restrict: 'EA',
            transclude: true,
            replace: true,
            scope: {},
            templateUrl: 'carousel/carousel.tpl.html',
            controller: ['$scope', '$element', '$attrs', function ($scope, $element, $attrs) {
                var that = this, options = {};
                angular.forEach(['effect', 'speed', 'interval', 'keyboard', 'hoverStop', 'autoPlay', 'outerWidth', 'innerHeight'],
                    function (key) {
                        angular.isDefined($attrs[key]) && (options[key] = $helpers.parseConstant($attrs[key]))
                    })
                var ctrl = new $carousel($element, $scope, options)
                that = angular.extend(that, ctrl)
                return that;
            }]
        };
    }])
    .directive('carouselItem', ['$parse', function ($parse) {
        return {
            require: '^nqCarousel',
            restrict: 'EA',
            replace: true,
            template: '<div class="item" carousel-item-transclude="" ng-swipe-left="$parent.$next()"  ng-swipe-right="$parent.$prev()"></div>',
            transclude: true,
            scope: {
                active: '=?',
                heading: '@',
            },
            controller: function () {
            },
            compile: function (elm, attrs, transclude) {
                return function postLink(scope, elm, attrs, controller) {
                    scope.effect = controller.$options.effect;
                    scope.speed = controller.$options.speed;
                    angular.isDefined(attrs.effect) && (scope.effect = attrs.effect)
                    angular.isDefined(attrs.speed) && (scope.effect = attrs.speed)


                    scope.select = function (index) {
                        index = index || scope.$index || 0;
                        controller.select(index);
                    };
                    controller.addItem(scope);
                    scope.$on('$destroy', function () {
                        controller.removeItem(scope);
                    });

                    scope.$transcludeFn = transclude;
                };
            }
        };
    }])

    .directive('indicatorTransclude', [function () {
        return {
            restrict: 'A',
            require: '^nqCarousel',
            link: function (scope, elm, attrs, controller) {
                var item = scope.$eval(attrs.indicatorTransclude);
                if (controller.$watchIndicator && scope.$first) {
                    controller.thumbWidth = elm.width();
                    controller.thumbHeight = elm.height();
                    controller.visibleThumb = parseInt((elm.closest('.carousel').width() - 100) / controller.thumbWidth)
                }
                scope.$watch(function () { return item.thumbImage }, function (image) {
                    if (image) {
                        angular.element(image).on('load',function () {
                            var c = document.createElement("canvas"),
                                w = controller.thumbWidth,
                                h = controller.thumbHeight,
                            ow = controller.$options.outherWidth;
                            c.width = w - 2; c.height = h - 2;
                            c.getContext("2d").drawImage(this, 0, 0, w - 2, h - 2);

                            elm.html(c)
                        });
                    }
                });
                if (controller.$watchIndicator) {
                    scope.$watch(function () { return controller.$lastIndex }, function (index) {
                        if (controller.visibleThumb > 0) {
                            if (scope.$index + controller.visibleThumb < (index + 2))
                                elm.hide();
                            else if (elm.css('display') == 'none')
                                elm.show();
                        }
                    });
                }
            }
        };
    }])
    .directive('carouselItemTransclude', ['$animate', '$timeout', function ($animate, $timeout) {
        return {
            restrict: 'A',
            require: '^carouselItem',
            link: function (scope, elm, attrs, controller) {
                scope.$watch('$transcludeFn', function (value) {
                    scope.$transcludeFn(scope.$parent, function (contents) {
                        angular.forEach(contents, function (node) {
                            var nodeEl = angular.element(node)
                            if (nodeEl.hasClass('thumb-image')) {
                                scope.thumbImage = nodeEl;
                            }
                            else if (nodeEl.hasClass('generate-thumb')) {
                                scope.thumbImage = nodeEl;
                                elm.append(node);
                            }
                            else
                                elm.append(node);
                        });
                    });
                });
                scope.$watch('active', function (value) {
                    value ? show() : hide();
                });
                function show() {
                    elm.show();
                    if (scope.effect) {
                        elm.addClass(scope.speed)
                        $animate.addClass(elm, scope.effect).then(function () {
                        });
                    }

                }
                function hide() {
                    if (scope.effect) {
                        
                        $animate.removeClass(elm, scope.effect).then(function () {
                            elm.hide();
                        });
                        elm.animationEnd(function (evt) {
                            !scope.active &&  elm.hide();
                        });
                    }
                    else
                        elm.hide();
                }
            }
        };
    }]);
}(window, window.angular);
+function (window, angular, undefined) {
'use strict';
    angular.module('ngQuantum.collapse', [])
    .provider('$collapse', function () {
        var defaults = this.defaults = {
            dimension: 'height',
            collapsed:true
        };
        this.$get = ['$timeout', '$rootScope',
          function ($timeout, $rootScope) {
              function Factory(target, element, config) {
                  var $collapse = {}, position, size, dimension, collapsed;
                  var options = $collapse.$options = angular.extend({}, defaults, config);
                  dimension = options.dimension;
                  $collapse.collapsed = options.collapsed;
                 target.addClass('collapse');
                 if (!$collapse.collapsed) {
                     target.addClass('in');
                     size = target[dimension]();
                 }
                  function toggle() {
                      if ($collapse.collapsed) {
                          position = target[0].style.position || '';
                          target.css('position', 'absolute').show();
                          var dm = dimension == 'height' ? 'outerHeight' : 'outerWidth';
                          size = target[dm]();

                          target.css('display', '')[dimension](0).css('position', position);
                          target.addClass('in collapsing');
                          setTimeout(function () {
                              target[dimension](size)
                              .transitionEnd(function () {
                                  target.removeClass('collapsing');
                                  $collapse.collapsed = false;
                                  options.onToggle && options.onToggle(false);
                                  target[dimension]('');
                              });
                          }, 1)

                      } else {
                          size = target[dimension]();
                          target[dimension](size)
                          setTimeout(function () {
                              target.addClass('collapsing')[dimension](0)
                              .transitionEnd(function () {
                                  target[dimension]('');
                                  target.removeClass('collapsing').removeClass('in').css(dimension, '');
                                  $collapse.collapsed = true;
                                  options.onToggle && options.onToggle(true);
                              });
                          }, 1)
                          
                      }
                  }
                  element && element.on('click', function (evt) {
                      evt.preventDefault();
                      evt.stopPropagation();
                      toggle();

                  });
                  options.checkRouting && $rootScope.$on('$locationChangeStart', function (event, viewConfig) {
                      if (!$collapse.collapsed) {
                          $collapse.collapsed = false;
                          toggle();
                      }
                      
                  });
                  $collapse.toggle = toggle;
                  return $collapse;
              }
              return Factory;
          }
        ];
    })
    .directive('nqAccordion', function () {
        return {
            restrict: 'A',
            require: '?ngModel',
            compile: function(element, attr) {
                var model = attr.ngModel;
                if (!model)
                    model = 'accordionModel' + Math.floor((Math.random() * 1000) + 1).toString();
                element.removeAttr('ng-model');
                var children = element.find('> .panel');
                
                angular.forEach(children, function (child, key) {
                    var childEl = angular.element(child),
                    target = childEl.find('.panel-collapse');
                    if (target.length) {
                        var id = target.attr('id')
                        if (!id) {
                            id = model + Math.floor((Math.random() * 1000) + 1).toString()
                            target.attr('id', id)
                        }
                        var link = childEl.find('.panel-title > a');
                        if (!link.length)
                            link = childEl.find('.panel-title');
                        if (!link.length)
                            link = childEl.find('.panel-heading');
                        if (link.length) {
                            link.attr('target-index', key);
                            link.attr('target-id', '#' +id);
                            link.attr('data-ng-click', model + "=" + model + "==" + key + "?" + 20000000 + ":" + key)
                            link.attr('ng-model', model);
                            link.attr('nq-collapse', '');
                        }
                        
                    }
                    

                });

            }
        };
    })
    .directive("nqCollapse", ['$collapse',function ($collapse) {
            return {
                restrict: 'EAC',
                require: '?ngModel',
                compile: function (tElm, tAttrs, transclude) {
                    var collapsed = true, target = angular.element(tAttrs.targetId),
                        dimension = angular.isDefined(tAttrs.dimension) && tAttrs.dimension == 'width' ? tAttrs.dimension : 'height';
                    if (angular.isDefined(tAttrs.collapsed) && (tAttrs.collapsed == 'false' || tAttrs.collapsed == false))
                        collapsed = false;
                    var options = {
                        collapsed: collapsed,
                        dimension: dimension,
                        checkRouting: tAttrs.checkRouting || tElm.hasClass('navbar-toggle')
                    }
                    var index = tAttrs.targetIndex ? parseInt(tAttrs.targetIndex) : 0,
                        collapse,
                        elm = !angular.isDefined(tAttrs.ngModel) ? tElm : null;
                    if (target.length) {
                        collapse = new $collapse(target, elm, options)
                    }

                    return function postLink(scope, element, attr, controller) {
                        collapse && angular.isDefined(tAttrs.ngModel) && scope.$watch(attr.ngModel, function (value, old) {
                            if (value == undefined)
                                return;
                            if (value == index || !collapse.collapsed)
                                collapse.toggle();
                        })

                    }
                }
            };
        }]);
}(window, window.angular);
+function (window, angular, undefined) {
'use strict';
    angular.module('ngQuantum.colorpicker', ['ngQuantum.popMaster'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('colorpicker/colorpicker.tpl.html',
                    '<div class="popover colorpicker">'
                    + '<ul class="nav palettes-list clearfix">'
                        + '<li ng-repeat="color in palettes"  ng-click="$parent.$select($index)">'
                            + '<span class="color-pick titip-top" data-title="{{color}}" ng-style="{\'background-color\':color}"></span>'
                        + '</li>'
                    + '</ul>'
                    + '<div class="clearfix">'
                        + '<span class="color-pick titip-top" data-title="{{selectedColor}}" ng-style="{\'background-color\':selectedColor}"></span>&nbsp;&nbsp;'
                        + '<span class="color-pick titip-top" ng-click="$select(\'transparent\')" data-title="Set Transparent" style="background-color:transparent;"></span>'
                        + '<small class="pull-right color-more-label" ng-click="$showPicker()">{{$options.moreText || \'More\'}} <i ng-class="$options.iconDown" class="angle-down"></i><i ng-class="$options.iconUp" class="angle-up"></i></small>'
                    + '</div>'
                    + '<div class="color-selector-panel">'
                        + '<ul class="clearfix nav-color-current">'
                           + '<li class="color-current-label">Current</li>'
                           + '<li><span class="color-current"  ng-style="{\'background-color\':selectedColor || newColor }"></span><span class="color-new" ng-style="{\'background-color\':newColor || selectedColor}"></span></li>'
                           + '<li class="color-new-label">New</li>'
                       + '</ul>'
                       + '<div class="clearfix">'
                           + '<div class="color-saturation"><span class="sat-point"></span></div>'
                           + '<div class="color-hue"><span class="hue-slider"></span></div>'
                       + '</div>'
                       + '<div class="clearfix alpha-row">'
                           + '<div class="color-alpha"><span class="alpha-slider titip-top titip-yellow titip-xs"><span class="titip-content">{{$alphaValue}}%</span></span></div>'
                           + '<div class="color-button"><button type="button" class="btn btn-default" ng-click="$select()">ok</button></div>'
                       + '</div>'
                    + '</div>'
                + '</div>'
        )
    }])
        
    
    .provider('$colorPicker', function () {
        var defaults = this.defaults = {
            palette: [
            '#000000', '#424242', '#636363', '#9C9C94', '#CEC6CE', '#EFEFEF', '#F7F7F7', '#FFFFFF',
            '#FF0000', '#FF9C00', '#FFFF00', '#00FF00', '#00FFFF', '#0000FF', '#9C00FF', '#FF00FF',
            '#F7C6CE', '#FFE7CE', '#FFEFC6', '#D6EFD6', '#CEDEE7', '#CEE7F7', '#D6D6E7', '#E7D6DE',
            '#E79C9C', '#FFC69C', '#FFE79C', '#B5D6A5', '#A5C6CE', '#9CC6EF', '#B5A5D6', '#D6A5BD',
            '#E76363', '#F7AD6B', '#FFD663', '#94BD7B', '#73A5AD', '#6BADDE', '#8C7BC6', '#C67BA5',
            '#CE0000', '#E79439', '#EFC631', '#6BA54A', '#4A7B8C', '#3984C6', '#634AA5', '#A54A7B',
            '#9C0000', '#B56308', '#BD9400', '#397B21', '#104A5A', '#085294', '#311873', '#731842',
            '#630000', '#7B3900', '#846300', '#295218', '#083139', '#003163', '#21104A', '#4A1031'
            ],
            paletteOnly: true,
            showAlpha: true,
            defaultColor: '#000000',
            effect: 'sing',
            typeClass: 'popover',
            prefixClass: 'colorpicker',
            prefixEvent: 'colorpicker',
            instanceName: 'colorpicker',
            placement: 'bottom-left',
            template: 'colorpicker/colorpicker.tpl.html',
            trigger: 'click',
            container: 'body',
            showArrow: true,
            allowWrite: false,
            autoHide: false,
            iconDown: 'fic fu-angle-d',
            iconUp: 'fic fu-angle-u',
            moreText: 'More',
            html: true,
            displayReflow: false,
            fireEmit: true,
            keyboard: true,
            overseeingTarget: true
        };
        this.$get = ['$rootScope', '$popMaster', '$document', '$color', '$mouse','$helpers',
          function ($rootScope, $popMaster, $document, $color, $mouse, $helpers) {
              function Factory(element, config, attr) {
                  var $picker = {}, alpha, hue, saturation, target, count = 0, sizes, hueSlider, satPoint, alphaSlider;
                  config = $helpers.parseOptions(attr, config);
                  var options = angular.extend({}, defaults, config);
                  var $picker = new $popMaster(element, options);
                  var scope = $picker.$scope;
                  options = $picker.$options = $helpers.observeOptions(attr, $picker.$options);
                  scope.$$postDigest(function () {
                      scope.palettes = options.palette;
                      scope.$select = $picker.select;
                      scope.$alphaValue = 100;
                      scope.$options = $picker.$options;
                  });
                  scope.$showPicker = function () {
                      $picker.$target.toggleClass('picker-open');
                      if ($picker.$target.hasClass('picker-open')) {
                          bindMouse();
                          setPositions();
                      }
                      else
                          unbindMouse();

                  }
                  var init = $picker.init;
                  $picker.init = function () {
                      init();
                      findElement();
                      scope.selectedColor = scope.newColor = scope.selectedColor || options.defaultColor || '#FF0000';
                      scope.$color.setColor(scope.selectedColor);
                  }
                  var show = $picker.show;
                  $picker.show = function () {
                     return show();
                  }
                  var hide = $picker.hide;
                  $picker.hide = function () {
                      var promise = hide();
                      unbindMouse();
                      $picker.$target.removeClass('picker-open');
                      return promise;
                  }
                  var destroy = $picker.destroy
                  $picker.destroy = function () {
                      destroy();
                      unbindMouse();
                      scope.$destroy();
                  }
                  $picker.select = function (index) {
                      var color = scope.selectedColor || '#FF0000';
                      if (index) {
                          if (index == 'transparent')
                              color = 'transparent';
                          else {
                              color = scope.palettes[index];
                              scope.$color.setColor(color);
                          }

                      }
                      else if (scope.$color) {
                          if (scope.$color.value.a == 1)
                              color = scope.$color.hex()
                          else
                              color = scope.$color.rgba();
                          $picker.$target.removeClass('picker-open');
                      }
                      scope.selectedColor = color;
                  }
                  function findElement() {
                      target = $picker.$target;
                      if (!target && count < 10) {
                          setTimeout(function () {
                              findElement()
                              count++;
                          }, 50)
                      }
                      else {
                          !scope.$color && (scope.$color = $color)
                          hue = target.find('.color-hue');
                          alpha = target.find('.color-alpha');
                          saturation = target.find('.color-saturation');
                          hueSlider = hue.find('.hue-slider');
                          satPoint = saturation.find('.sat-point');
                          alphaSlider = alpha.find('.alpha-slider');
                      }
                  }

                  function bindMouse() {
                      if (!sizes)
                          findSizes();
                      hueMouse();
                      saturationMouse();
                      alphaMouse();
                  }
                  function unbindMouse() {
                      $mouse.offDown(saturation)
                      $mouse.offDown(satPoint);
                      $mouse.offDown(hue)
                      $mouse.offDown(hueSlider);
                      $mouse.offDown(alpha)
                      $mouse.offDown(alphaSlider);
                  }
                  function hueMouse() {
                      $mouse.down(hue, slideHue)
                      $mouse.down(hueSlider, function (event) {
                          $mouse.offMove($document, slideHue);
                          $mouse.move($document, slideHue);
                          var upHandler = function (event) {
                              $mouse.offMove($document, slideHue);
                              $mouse.offUp($document, upHandler);
                          };
                          $mouse.up($document, upHandler)
                      })

                  }
                  function saturationMouse() {
                      $mouse.down(saturation, dragSaturation)
                      $mouse.down(satPoint, function (event) {
                          $mouse.offMove($document, dragSaturation)
                          $mouse.move($document, dragSaturation);
                          var upHandler = function (event) {
                              $mouse.offMove($document, dragSaturation)
                              $mouse.offUp($document, upHandler);
                          };
                          $mouse.up($document, upHandler)
                      })


                  }
                  function alphaMouse() {
                      $mouse.down(alpha, slideAlpha)
                      $mouse.down(alphaSlider, function (event) {
                          $mouse.offMove($document, slideAlpha)
                          $mouse.move($document, slideAlpha);
                          var upHandler = function (event) {
                              $mouse.offMove($document, slideAlpha)
                              alphaSlider.removeClass('titip-active');
                              $mouse.offUp($document, upHandler)
                          };
                          $mouse.up($document, upHandler)
                      })


                  }
                  function slideHue(event) {
                      var y = $mouse.relativeY(event, hue);
                      y = y > sizes.hh ? sizes.hh : y < 0 ? 0 : y;
                      hueSlider.css({ top: y - (sizes.hsh / 2) });
                      setHue((y / sizes.hh));
                  }
                  function dragSaturation(event) {
                      var pos = $mouse.relativePos(event, saturation);
                      var x = pos.left, y = pos.top;
                      y = y > sizes.hh ? sizes.hh : y < 0 ? 0 : y;
                      x = x > sizes.aw ? sizes.aw : x < 0 ? 0 : x;

                      satPoint.css({ left: x - (sizes.spw / 2), top: y - (sizes.sph / 2) });
                      setSaturation((x / sizes.sw), 1 - (y / sizes.sh));
                  }
                  function slideAlpha(event) {
                      alphaSlider.addClass('titip-active')
                      var x = $mouse.relativeX(event, alpha);
                      x = x > sizes.aw ? sizes.aw : x < 0 ? 0 : x;
                      alphaSlider.css({ left: x - (sizes.asw / 2) });
                      setAlpha((x / sizes.aw));
                  }

                  function findSizes() {
                      sizes = {
                          hh: hue.height(),
                          hsh: hueSlider.outerHeight(),
                          sw: saturation.width(),
                          sh: saturation.height(),
                          sph: satPoint.outerHeight(),
                          spw: satPoint.outerWidth(),
                          aw: alpha.width(),
                          asw: alphaSlider.outerWidth()
                      }
                  }
                  function drawAlphaBg() {
                      var color = scope.$color.hex();
                      alpha.css('background-image', 'linear-gradient(to right, rgba(255,255,255, 0), ' + color + ')')
                      scope.newColor = scope.$color.rgba();
                      !scope.$$phase && scope.$apply(function () {
                          scope.newColor = scope.$color.rgba();
                      })

                  }
                  function setPositions() {
                      if (!sizes)
                          findSizes();
                      var satpos = {
                          left: (scope.$color.value.s * sizes.sw) - (sizes.spw / 2),
                          top: ((1 - scope.$color.value.b) * sizes.sw) - (sizes.sph / 2)
                      }
                      satPoint.css(satpos)
                      hueSlider.css({ top: (scope.$color.value.h * sizes.hh) - (sizes.hsh / 2) });
                      alphaSlider.css({ left: (scope.$color.value.a * sizes.aw) - (sizes.asw / 2) });
                      scope.$alphaValue = parseInt(scope.$color.value.a * 100);
                      saturation.css('background-color', $color.toHex(scope.$color.value.h, 1, 1, 1))
                      drawAlphaBg();
                  }
                  function setHue(value) {
                      scope.$color.setHue(value);
                      saturation.css('background-color', $color.toHex(value, 1, 1, 1))
                      drawAlphaBg()
                  }
                  function setSaturation(sat, bright) {
                      scope.$color.setSaturation(sat);
                      scope.$color.setLightness(bright);
                      drawAlphaBg();
                  }
                  function setAlpha(value) {
                      scope.$color.setAlpha(value);
                      scope.$apply(function () {
                          scope.$alphaValue = parseInt(value * 100);
                      })
                      drawAlphaBg();
                  }
                  return $picker;
              }
              return Factory;
          }
        ];
    })
    .directive('nqColorPicker', ['$colorPicker', function ($colorPicker) {
        return {
            restrict: 'AC',
            require: 'ngModel',
            link: function postLink(scope, element, attr, controller) {
                var options = {
                    $scope: scope.$new()
                };
                var picker = new $colorPicker(element, options, attr)
                scope.$watch(attr.ngModel, function (newVal, oldVal) {
                    if (newVal && (newVal !== picker.$scope.selectedColor)) {
                        picker.$scope.selectedColor = newVal;
                    }
                })

                picker.$scope.$watch('selectedColor', function (newVal, oldVal) {
                    if (newVal && (newVal !== oldVal)) {
                        controller.$setViewValue(picker.$scope.selectedColor);
                        controller.$render();
                    }
                })
                scope.$on('$destroy', function () {
                    picker && picker.destroy();
                    picker = null

                })
            }
        };
    }]);
}(window, window.angular);
(function (moment) {
    if(!moment)
        return;
    moment.fn.clearTime = function () {
        this.hours(0);
        this.minutes(0);
        this.seconds(0);
        this.milliseconds(0);
        return this;
    };
    moment.fn.isWeekend = function () {
        var d = this.day()
        return (d == 6 || d == 0) || false;
    };
    moment.fn.isToday = function () {
        return (this.clone().clearTime().valueOf() == moment().clearTime().valueOf());
    };
    moment.fn.toObject = function () {
            var m = this;
            return {
                year: m.year(),
                month: m.month(),
                date: m.date(),
                hour: m.hours(),
                minute:m.minutes(),
                second:m.seconds(),
                millisecond:m.milliseconds()
            }
    }

})(window.moment);
+function (window, angular, undefined) {
'use strict';
angular.module('ngQuantum.datepicker', [
      'ngQuantum.popMaster'
    ])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('datepicker/datepicker.tpl.html',
          "<div tabindex=\"-1\" class=\"calendar-panel\" role=\"listbox\"><div tabindex=\"-1\" class=\"calendar-header\" role=\"listbox\"></div><div tabindex=\"-1\" class=\"calendar-body\" role=\"listbox\"></div><div tabindex=\"-1\" class=\"calendar-footer\" role=\"listbox\"></div></div>"
        );

    }])
    .provider('$datepicker', function () {
        var defaults = this.defaults = {
            format: 'MM-DD-YYYY',
            timeFormat: 'HH:mm:ss',
            headerFormat: 'MMMM YYYY',
            timepicker: false,
            datepicker: true,
            rangepicker: false,
            timeView: false,
            showEvents: false,
            weekNumber: false,
            minDate: false,
            minDateFrom: false,
            maxDate: false,
            startDate: false,
            minHour: 0,
            maxHour: 23,
            divideHour: 4,
            defaultTime: false,
            timesSet: [], //to do
            todayButton: true,
            rangeType: 'day',
            minRange: 1,
            maxRange: false,
            defaultSelect: true, //to do
            allowBlank: false, //to do
            showYears: true,
            minYear: 1950,
            maxYear: 2050,
            dayOfWeekStart: 1,
            disableWeekends: false,
            disableWeekdays: [],
            specialDays: [], //to do
            dayHeader: 'shortest',
            effect: 'flip-y',
            typeClass: 'datepicker',
            prefixClass: 'calendar',
            prefixEvent: 'datepicker',
            instanceName: 'datepicker',
            placement: 'bottom-left',
            template: 'datepicker/datepicker.tpl.html',
            trigger: 'click',
            container: 'body',
            showArrow: true,
            allowWrite: false,
            autoHide: true,
            html: true,
            displayReflow: false,
            fireEmit: true,
            keyboard: true, //to do
            show: false,
            inline: false,
            theme:'default',
            selectable: true,
            readonly :  true,
            overseeingTarget: true,
            modelType:'date',
            nextIcon: 'fic fu-angle-r',
            prevIcon: 'fic fu-angle-l',
            todayIcon: 'fic fu-restore',
            closeIcon: 'fic fu-cross',
            timeIcon: 'fic fu-time',
            downIcon: 'fic fu-angle-d',
            upIcon: 'fic fu-angle-u'
        };
        this.$get = [
          '$compile',
          '$popMaster',
          '$parse',
          '$helpers',
          '$timeout',
          function ($compile, $popMaster, $parse, $helpers, $timeout) {
              function Factory(element, config, attr, ngModel) {
                  config = $helpers.parseOptions(attr, config);
                  var options = angular.extend({}, defaults, config);
                  if (options.inline) {
                      options.show = true;
                      options.trigger = false;
                      options.showArrow = false;
                      options.container = 'self';
                      element.addClass('calendar-inline');
                      options.effect = false;
                      options.autoHide = false;
                      options.readonly = false;
                  }
                  var $picker = new $popMaster(element, options);
                  var scope = $picker.$scope; var $target, $header, $body, $footer, yearSelector, table, tbody, initialized, lastCacheKey, keyTarget;

                  scope.$options = options = $helpers.observeOptions(attr, options);

                  $picker.caches = {};

                  angular.forEach(['next', 'before', 'today', 'gotoYear'], function (value) {
                      scope['$' + value] = function (evt) {
                          scope.$$postDigest(function () {
                              $picker[value](evt);
                          });
                      }
                  })
                  scope.$gotoYear = function (val, evt) {
                      if (evt) {
                         evt.preventDefault();
                          $picker.preventHide = true;
                      }
                      
                      scope.$$postDigest(function () {
                          $picker.gotoYear(val)
                      });
                  }
                  scope.$select = function (val, type) {
                      scope.$$postDigest(function () {
                          $picker.select(val, type)
                      });
                  }
                  scope.$setTime = function (val) {
                      scope.$$postDigest(function () {
                          $picker.setTime(val)
                      });
                  }
                  scope.$changeTime = function (dir, type, val) {
                      scope.$$postDigest(function () {
                          $picker.changeTime(dir, type, val)
                      });
                  }

                  var init = $picker.init;
                  $picker.init = function () {
                      optimize();
                      init();
                      if (!initialized) {
                          initialized = true;
                          buildScope();
                      }
                      if (!options.allowWrite) {
                          element.on('keydown', function () {
                              return false;
                          })
                      }
                      $target = $picker.$target;
                  }
                  var show = $picker.show;
                  $picker.show = function () {
                      if (!$picker.$builded) {
                          buildFirst();
                      }
                      var promise = show();
                      promise && promise.then(function () {
                          formatPicker();
                          $target.focus();
                      })
                      if (options.keyboard && $picker.$target) {
                          angular.element(document).off('keydown', $picker.$onKeyDown);
                          angular.element(document).on('keydown', $picker.$onKeyDown);
                      }
                      return promise;
                  }
                  var hide = $picker.hide;
                  $picker.hide = function () {
                      if ($picker.preventHide)
                      {
                          $picker.preventHide = false;
                          return false;
                      }
                      var promise = hide();
                      promise && promise.then(function () {
                          if (scope.$timeViewActive && options.datepicker)
                              scope.$toggleTimepicker();
                          element && element.focus();
                      })
                      if (options.keyboard && $picker.$target) {
                          angular.element(document).off('keydown', $picker.$onKeyDown);
                      }
                      return promise;
                  }
                  var destroy = $picker.destroy;
                  $picker.destroy = function () {
                      destroy();
                      scope.$destroy();
                  }
                  $picker.next = function () {
                      $picker.changeDate('up', 'month', 1)
                  }
                  $picker.before = function () {
                      $picker.changeDate('down', 'month', 1)
                  }
                  $picker.changeDate = function (dir, type, val) {
                      var v = !val ? 1 : angular.isNumber(val) ? val : window.isNaN(parseInt(val)) ? 1 : parseInt(val);
                      v = dir == 'down' ? -v : v;
                      type = type || 'day';
                      var dt = scope.currentDate.clone().add(v, type);
                      if (scope.minDate && dt.clone().endOf('month') < scope.minDate)
                          return;
                      if (scope.maxDate && dt.clone().startOf('month') > scope.maxDate)
                          return;
                      apply(function () {
                          if (scope.minDate && dt < scope.minDate) {
                              dt = scope.minDate.clone();
                          }
                         if (scope.maxDate && dt > scope.maxDate) {
                              dt = scope.maxDate.clone();
                          }
                          if (options.disableWeekdays.length) {
                              while (options.disableWeekdays.indexOf(dt.day()) > -1)
                                  dt.add(1, 'day')
                          }
                          scope.selectedDay = dt.month() + '-' + dt.date();
                          scope.currentDate = dt.clone();
                          fireChange(type)
                          buildNew()
                      });
                  }
                  $picker.today = function (evt) {
                      if (evt) {
                          evt.preventDefault();
                          $picker.preventHide = true;
                      }
                      apply(function () {
                          scope.currentDate = scope.minDate && scope.startDate < scope.minDate ? scope.minDate.clone() : scope.maxDate && scope.startDate > scope.maxDate ? scope.maxDate.clone() : scope.startDate.clone();
                          buildNew()
                          scope.modelSetted = true;
                          renderModel();
                          fireChange();
                          scope.selectedDay = scope.currentDate.month() + '-' + scope.currentDate.date();
                      })

                  }
                  $picker.gotoYear = function (val) {
                      apply(function () {
                          scope.currentDate.year(val);
                          buildNew();
                          scope.modelSetted = true;
                          renderModel();
                          fireChange('year')
                      })

                  }
                  $picker.setTime = function (val) {
                      var date = scope.currentDate.clone();
                      var h = parseInt(val.split(':')[0]);
                      var m = parseInt(val.split(':')[1]) || 0;
                      if (window.isNaN(h))
                          h = options.minHour;
                      date.hour(h)
                      date.minute(m)
                      apply(function () {
                          scope.currentDate = date;
                          scope.modelSetted = true;
                          renderModel();
                          fireChange('time');
                      })
                      if (options.datepicker)
                          scope.$toggleTimepicker();
                      else if (options.autoHide)
                          $picker.hide();
                  }
                  $picker.changeTime = function (dir, type, val) {
                      var v = !val ? 1 : angular.isNumber(val) ? val : window.isNaN(parseInt(val)) ? 1 : parseInt(val);
                      v = dir == 'down' ? -v : v;
                      var dt = scope.currentDate.clone().add(v, type),
                          dth = dt.hour();
                      if (dth >= options.minHour && dth <= options.maxHour) {
                          scope.currentDate = dt.clone();
                          scope.modelSetted = true;
                          renderModel();
                          fireChange(type)
                      }
                  }
                  $picker.$onKeyDown = function (e) {
                      if (!/(13|37|38|39|40)/.test(e.keyCode))
                          return true;
                      if (!e.isDefaultPrevented()) {
                          
                          var timeView = scope.$timeViewActive,
                              dir, type;
                          var code = e.keyCode, evt = e;
                          if (!timeView) {
                              e.preventDefault();
                              switch (code) {
                                  case 37:
                                  case 38:
                                      dir = 'down';
                                      type = e.ctrlKey ? (code == 37 ? 'month' : 'year') : (code == 37 ? 'day' : 'week');
                                      break;
                                  case 39:
                                  case 40:
                                      dir = 'up'
                                      type = e.ctrlKey ? (code == 39 ? 'month' : 'year') : (code == 39 ? 'day' : 'week');
                                      break;
                              }
                              if (code == 13) {
                                  if (e.altKey)
                                      $picker.today();
                                  else
                                      renderModel();
                              }
                              else
                                  dir && type && $picker.changeDate(dir, type, 1);
                          } else if (code == 13) {
                              if (options.timepicker && options.datepicker && e.ctrlKey)
                                  scope.$toggleTimepicker();
                              else if(e.target.tagName.toLowerCase() == 'a')
                                  angular.element(e.target).triggerHandler('click')
                          }
                          
                      }
                      return true;
                  };
                  function buildFirst(disablenew) {
                      $target = $picker.$target;
                      if (!$target)
                          return;
                      getElements($target);
                      if (options.rangepicker)
                          $target.addClass('picker-datarange')
                      else if (options.timepicker)
                          $target.addClass('picker-datetime')
                      else
                          $target.addClass('picker-date')
                      if (options.datepicker)
                          buildHeader();
                      if (options.timepicker)
                          buildTimeSelector();
                      if (options.showYears && options.datepicker)
                          buildYearSelector();
                      if (options.datepicker && !disablenew)
                          buildNew();
                      if (options.timepicker && !options.datepicker)
                          $picker.$builded = true;

                      
                  }
                  function buildNew() {
                      if (!$body) {
                          buildFirst(true);
                      }

                      if (options.timepicker && !options.datepicker)
                          return;
                      var cachekey = cacheKey(scope.currentDate);
                      if (lastCacheKey && cachekey == lastCacheKey)
                          return;
                      lastCacheKey = cachekey;
                      var data = $picker.caches[cachekey];

                      if (!data) {
                          data = createCache(cachekey);
                      }
                      apply(function () {
                          scope.dayArray = data.dayArray;
                      })

                      $body.find('td.selected').removeClass('selected');
                      tbody.html(data.content);
                      $compile($body)(scope);
                      $picker.$builded = true;
                  }
                  function createCache(cachekey) {
                      var start = scope.currentDate
                      var dArr = [];
                      var month = start.month();
                      var mStart = start.clone().startOf('month');
                      var mEnd = mStart.clone().endOf('month');
                      var dow = parseInt(options.dayOfWeekStart);
                      var wStart = mStart.clone().day(dow)
                      var wEnd = mEnd.clone().day(dow)
                      if (wStart > mStart)
                          wStart.add(-7, 'day')
                      if (wEnd <= mEnd)
                          wEnd.add(7, 'day')

                      var diff = wEnd.diff(wStart, 'day')
                      for (var d = 0; d < diff; d++) {
                          var day = wStart.clone().add(d, 'day');
                          var item = {
                              day: day.date(),
                              month: day.month(),
                              isWeekend: day.isWeekend()
                          }
                          if (options.disableWeekdays.length && options.disableWeekdays.indexOf(day.day()) > -1) {
                              item.unselectable = true;
                          }
                          if (month != day.month()) {
                              item.outMonth = true;
                          }
                          if (options.weekNumber)
                              item.week = day.week();
                          if (scope.minDate && day < scope.minDate)
                              item.unselectable = true;
                          if (scope.maxDate && day > scope.maxDate)
                              item.unselectable = true;
                          dArr.push(item);
                      }
                      $picker.caches[cachekey] = { 'dayArray': dArr };
                      scope.dayArray = dArr;
                      $picker.caches[cachekey].content = buildTable();
                      return $picker.caches[cachekey];
                  }
                  function getElements(target) {
                      $header = target.find('.calendar-header');
                      $body = target.find('.calendar-body');
                      $footer = target.find('.calendar-footer');
                  }
                  function detectDate(dDate, defaultDate) {
                      var value = angular.isString(dDate) ? moment(dDate, options.format) : angular.isDate(dDate) ? moment(dDate) : moment.isMoment(dDate) ? dDate.clone() : defaultDate;
                      return moment.isMoment(value) ? value :moment()
                  }
                  function optimize() {
                      if (!options.datepicker && !options.timepicker)
                          options.datepicker = true;
                      if (!angular.isArray(options.disableWeekdays))
                          options.disableWeekdays = [];
                      if (options.disableWeekends)
                          options.disableWeekdays = options.disableWeekdays.concat([0, 6])
                      if (options.minDate) {
                          if (options.minDate == 'today') {
                              scope.minDate = moment();
                          }
                          else
                              scope.minDate = detectDate(options.minDate, moment())
                          options.minYear = scope.minDate.year();
                          scope.minDate.clearTime();
                      }
                      if (options.maxDate) {
                          scope.maxDate = detectDate(options.maxDate, moment())
                          options.maxYear = scope.maxDate.year();
                          scope.maxDate.clearTime();
                      }

                      if (options.startDate) {
                          scope.startDate = detectDate(options.startDate, moment())
                      }
                      else
                          scope.startDate = scope.minDate && moment() < scope.minDate ? scope.minDate.clone() : scope.maxDate && moment() > scope.maxDate ? scope.maxDate.clone() : moment();
                      scope.currentDate = scope.startDate.clone();
                      scope.format = options.format;
                      if (options.disableWeekdays.length)
                          while (options.disableWeekdays.indexOf(scope.currentDate.day()) > -1)
                              scope.currentDate.add(-1, 'day');
                      if (options.timepicker) {
                          options.minHour = angular.isNumber(options.minHour) && (options.minHour >= 0) ? options.minHour : 8;
                          options.maxHour = angular.isNumber(options.maxHour) && options.maxHour || 22;
                          options.divideHour = angular.isNumber(options.divideHour) && options.divideHour || 4;
                          (options.minHour < 0 || options.minHour > 23) && (options.minHour = 0)
                             (options.maxHour > 24 || options.maxHour < 2) && (options.maxHour = 24)
                          if (options.divideHour > 30)
                              options.divideHour = 0;
                          else
                              while (60 % options.divideHour != 0)
                                  options.divideHour++;
                          optimizeTime();
                      }
                      else {
                          scope.currentDate.clearTime();
                      }
                      if (scope.currentDate.hour() < options.minHour)
                          scope.currentDate.hour(options.minHour).minute(0).second(0)
                      if (!options.defaultRange) {
                          options.defaultRange = options.minRange;
                      }
                      scope.selectedDay = scope.currentDate.month() + '-' + scope.currentDate.date();
                  }
                  function buildTable() {
                      if (!$body) {
                          buildFirst(true);
                      }
                      if (!table) {
                          table = angular.element('<table/>').addClass('calendar-table');
                          var thead = angular.element('<thead/>').appendTo(table);
                          tbody = angular.element('<tbody/>').appendTo(table)
                          var tfoot = angular.element('<tfoot/>').appendTo(table);
                          var names = options.dayHeader == 'shortest' ? moment.localeData()._weekdaysMin || moment.localeData()._weekdaysShort : moment.localeData()._weekdaysShort;
                          if (options.dayOfWeekStart > 0) {
                              var first = names.slice(options.dayOfWeekStart, 7)
                              var cut = names.slice(0, options.dayOfWeekStart)
                              names = first.concat(cut);
                          }
                          var trhead = angular.element('<tr><th>' + names.join('</th><th>') + '</th></tr>').appendTo(thead);
                          if (options.weekNumber) {
                              table.addClass('has-week-no')
                              trhead.prepend('<th class="cal-week-no">W</th>')
                          }

                          var watch = function () { return table.width() };
                          scope.$watch(watch, function () { })();
                          scope.$watch(watch, function (newValue, oldValue) {
                              setTimeout(function () {
                                  yearSelector && yearSelector.css('width', table.width());
                              }, 0)
                          })
                          $body.html(table)
                      }
                      
                      return buildTableBody();
                  }
                  function buildTableBody() {
                      var tbody = angular.element('<tbody/>');
                      var rows = parseInt(scope.dayArray.length / 7)
                      if ((scope.dayArray.length % 7) > 0) rows++;
                      var idx = 0;
                      for (var r = 0; r < rows; r++) {
                          var trdate = angular.element('<tr></tr>').appendTo(tbody);
                          var last = (r + 1) * 7
                          if (last > scope.dayArray.length)
                              last = scope.dayArray.length;
                          var rdates = scope.dayArray.slice(r * 7, last);
                          if (options.weekNumber)
                              trdate.append('<th class="cal-week-no">' + rdates[0].week + '</th>');
                          angular.forEach(rdates, function (val, key) {
                              var slday = val.month + '-' + val.day;
                              var td = angular.element('<td cal-date-item="' + idx + '" ng-class="{selected:selectedDay==\'' + slday + '\'}">'+val.day+'</td>').appendTo(trdate);
                              if (val.unselectable)
                                  td.addClass('unselectable')
                              if (val.isWeekend)
                                  td.addClass('weekend')
                              if (val.outMonth)
                                  td.addClass('out-month')
                              idx++;
                          })

                      }

                      return tbody.html();
                  }
                  function buildHeader() {
                      var ul = '<table class="cal-header-table"><tr>' +
                                   '<td class="before"><button data-title="Before" class="titip-top" type="button" ng-click="$before()"><i ng-class="$options.prevIcon"></i></button></td>' +
                                   '<td class="date-head"><span>{{currentMonthTitle}}</span></td>' +
                                   '<td class="today"><button data-title="Today" class="titip-top" type="button" ng-click="$today($event)"><i ng-class="$options.todayIcon"></i></button></td>' +
                                   '<td class="next"><button data-title="Next" class="titip-top" type="button" ng-click="$next()"><i ng-class="$options.nextIcon"></i></button></td>' +
                                   '<td class="hide-cal"><button data-title="Close" class="titip-top" type="button" ng-click="$hide()"><i ng-class="$options.closeIcon"></i></button></td>' +
                               '</tr></table>';
                      ul = angular.element(ul)
                      $compile(ul)(scope);
                      $header.html(ul)
                  }
                  function buildYearSelector() {
                      if (options.showYears) {
                          yearSelector = angular.element('<div class="year-selector" ng-hide="yearsArray.length < 2" nq-scroll="" data-qo-axis="x" data-qo-bar-size="slimmest" data-qo-placement-offset="0" data-qo-visible="true"></div>').appendTo($footer);
                          var inner = angular.element('<div class="selector-inner"></div>').appendTo(yearSelector);
                          options.theme && yearSelector.attr('data-qo-theme', options.theme);
                          getYearArray();
                          inner.append('<a role="button" tabindex="1" id="year-{{year}}" ng-repeat="year in yearsArray" ng-click="$gotoYear(year, $event)" ng-class="{active:currentYear == year}"><span>{{year}}</span></a>');
                          $picker.yearSelector = yearSelector;
                          $compile(yearSelector)(scope);
                       
                      }

                  }
                  function getYearArray() {
                      scope.yearsArray = [];
                      for (var y = options.minYear; y <= options.maxYear; y++)
                          scope.yearsArray.push(y)
                  }
                  function buildTimeSelector() {
                      if (options.timepicker) {
                          var dpCont = angular.element('<div role="presentation" tabindex="-1" class="dp-container clearfix"></div>').appendTo($body),
                          tpCont = angular.element('<div class="tp-container clearfix"></div>').appendTo($body),
                          tpSwicher = angular.element('<div class="tp-switcher" time-picker-switch="" data-time-icon="$options.timeIcon"  data-close-icon="$options.closeIcon"></div>').appendTo(tpCont),
                          tpTemp = timePickerTemplate().appendTo(tpCont);

                          $compile(tpCont)(scope);
                          scope.timePickerTemp = $picker.timePickerTemp = tpTemp;
                          $body = dpCont;

                          scope.$toggleTimepicker = function () {
                              apply(function () {
                                  scope.timePickerTemp.toggle();
                                  $picker.yearSelector && $picker.yearSelector.toggle();
                                  $header.toggle();
                                  dpCont.toggle();
                                  tpCont.toggleClass('tp-visible');
                                  scope.$timeViewActive = !scope.$timeViewActive;
                                  
                                  if (scope.$timeViewActive) {
                                      (options.timeView == 'list') && scrollTime();
                                      dpCont.focus();
                                  }
                                      
                              });
                          }
                      }
                  }
                  function cacheKey(date) {
                      return date.year() + date.month();
                  }
                  function scrollYear() {
                      if ($picker.yearSelector) {
                          $timeout(function () {
                              var yelm = '#year-' + (scope.currentYear - 3)
                              var bar = $picker.yearSelector.data('$scrollBar');
                              bar && bar.scrollTo(yelm)
                          }, 0)
                          
                      }
                  }
                  function scrollTime() {
                      if ($picker.timeListContainer) {
                          $timeout(function () {
                              var yelm = $picker.timeListContainer.find('a.active')
                              if (yelm.length) {
                                  var bar = $picker.timeListContainer.data('$scrollBar');
                                  var lval = yelm[0].offsetTop - 30;

                                  bar && bar.scrollTo(lval);
                                  yelm.first().focus();
                              }
                              else
                                  $picker.timeListContainer.find('a').first().focus()
                          }, 0)
                          
                      }
                  }
                  function fireChange(type) {
                      switch (type) {
                          case 'date':
                          case 'day':
                          case 'month':
                          case 'year':
                              scope.$broadcast('pickerDateChanged');
                              break;
                          case 'hour':
                          case 'second':
                          case 'minute':
                          case 'time':
                              scope.$broadcast('pickerTimeChanged');
                              break;
                          default:
                              scope.$broadcast('pickerDatetimeChanged');
                              break;
                      }
                      apply(function () {
                          scope.currentDateObject = scope.currentDate.toObject();
                      })
                  }
                  function optimizeTime() {
                      if (options.timeView == 'list') {
                          options.format = options.format.replace(':ss', '').replace('ss', '');
                          var hr = scope.currentDate.hour();
                          if (hr < options.minHour)
                              scope.currentDate.hour(options.minHour)
                          else if (hr > options.maxHour)
                              scope.currentDate.hour(options.maxHour)

                          var m = scope.currentDate.minutes();
                          m = m - (m % parseInt(60 / options.divideHour))
                          scope.currentDate.minute(m)
                          scope.currentDate.second(0)
                          scope.currentTimeString = scope.currentDate.format('HH:mm');
                      }
                  }
                  function timePickerTemplate() {
                      var timePicker = angular.element('<div class="cal-timepicker"></div>');
                      var hh = options.format.indexOf('HH') > -1,
                          mm = options.format.indexOf('mm') > -1,
                          ss = options.format.indexOf('ss') > -1;
                      if (options.timeView != 'list') {
                          var tableTime = '<table class="tp-table"><tbody><tr>';
                          tableTime += hh ? '<td><button ng-class="\'btn-\' + $options.theme" type="button" class="btn tp-up" ng-click="$changeTime(\'up\',\'hour\')"><i ng-class="$options.upIcon"></i></button></td>' : ''
                          tableTime += hh ? '<td class="tp-seperator"></td>':'';
                          tableTime += mm ? '<td><button ng-class="\'btn-\' + $options.theme" type="button" class="btn tp-up" ng-click="$changeTime(\'up\',\'minute\')"><i ng-class="$options.upIcon"></i></button></td>':'';
                          tableTime += mm ? '<td class="tp-seperator"></td>':'';
                          tableTime += ss ? '<td><button ng-class="\'btn-\' + $options.theme" type="button" class="btn tp-up" ng-click="$changeTime(\'up\',\'second\')"><i ng-class="$options.upIcon"></i></button></td>':'';
                          tableTime += '</tr><tr>';
                          tableTime += hh ? '<td tp-bind-time="hour"></td>':'';
                          tableTime += hh ? '<td class="tp-seperator">:</td>':'';
                          tableTime += mm ? '<td tp-bind-time="minute"></td>':'';
                          tableTime += mm ? '<td class="tp-seperator">:</td>':'';
                          tableTime += ss ? '<td tp-bind-time="second"></td>':'';
                          tableTime += '</tr><tr>';
                          tableTime +=  hh ? '<td><button ng-class="\'btn-\' + $options.theme" type="button" class="btn tp-down" ng-click="$changeTime(\'down\',\'hour\')"><i ng-class="$options.downIcon"></i></button></td>':'';
                          tableTime +=  hh ? '<td class="tp-seperator"></td>':'';
                          tableTime +=  mm ? '<td><button ng-class="\'btn-\' + $options.theme" type="button" class="btn tp-down" ng-click="$changeTime(\'down\',\'minute\')"><i ng-class="$options.downIcon"></i></button></td>':'';
                          tableTime +=  mm ? '<td class="tp-seperator"></td>':''
                          tableTime +=  ss ? '<td><button ng-class="\'btn-\' + $options.theme" type="button" class="btn tp-down" ng-click="$changeTime(\'down\',\'second\')"><i ng-class="$options.downIcon"></i></button></td>':'';
                          tableTime += '</tr></tbody></table>';
                          timePicker.append(tableTime)
                      }
                      else {
                          var times = [];
                          if (!options.timesSet.length) {
                              var min = options.minHour,
                                  max = options.maxHour,
                                  dvd = options.divideHour;

                              var ratio = 60 / dvd;
                              for (var h = min; h < max; h++)
                                  for (var s = 0; s < dvd; s++) {
                                     var rs = s * ratio;
                                      var item = h < 10 ? '0' + h : h;
                                      item += ':'
                                      item += rs < 10 ? '0' + rs : rs;
                                      times.push(item)
                                  }
                              times.push(max + ':00')
                          }
                          else {
                              angular.forEach(options.timesSet, function (val) {
                                  val = val.replace(' ', '')
                                  validateHhMm(val) && times.push(val)
                              })
                          }
                          scope.timesList = times;
                          var timeListContainer = angular.element('<div class="tp-time-list" nq-scroll="" data-qo-bar-size="slimmest" data-qo-placement-offset="0" data-qo-visible="true"><a class="tp-time" role="button" tabindex="1" ng-repeat="time in timesList" tp-time-list-item="time"  ng-class="{active:$parent.currentTimeString == time}"></a></div>')
                          options.theme && timeListContainer.attr('data-qo-theme', '$options.theme');
                          timePicker.append(timeListContainer)
                          $picker.timeListContainer = timeListContainer;
                      }
                      return timePicker;
                  }
                  function validateHhMm(val) {
                      return /^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$/.test(val);
                  }
                  function renderModel() {
                      if (scope.hasModel) {
                          $timeout(function () {
                              if (options.modelType == 'date')
                                  ngModel.$setViewValue(scope.currentDate.clone().toDate());
                              else {
                                  ngModel.$setViewValue(scope.currentDate.format(scope.format));
                              }
                              ngModel.$commitViewValue();
                          }, 0)
                      }
                  }
                  function buildScope() {
                      angular.forEach(['onDateChange', 'onTimeChange', 'onChange'], function (key) {
                          if (angular.isDefined(options[key]) && !angular.isFunction(options[key]))
                              options[key] = $parse(options[key]);
                      })
                      if (ngModel) {
                          scope.hasModel = true;
                          var oldRender = ngModel.$render;
                          ngModel.$render = function (value) {
                              if (options.modelType == 'date') {
                                  var val = scope.currentDate.format(scope.format)
                                  if (element[0].tagName.toLowerCase() === 'input') {
                                      element.val(val);
                                  } else
                                      element.html(val);
                              } else {
                                  oldRender();
                              }
                          };
                          
                          scope.$parent.$watch(attr.ngModel, function (newValue, oldValue) {
                              if (newValue) {
                                  
                                  apply(function () {
                                      var dt;
                                      if (angular.isDate(newValue)) {
                                          options.modelType = 'date';
                                          dt = moment(newValue)
                                      } else
                                          dt = angular.isString(newValue) ? moment(newValue, scope.format) : moment.isMoment(newValue) ? newValue : moment();

                                      if (!dt.isValid())
                                          throw 'Type Error: ' + attr.ngModel + ' is not a valid Date, moment or date string...';
                                      if (options.timepicker) {
                                          var hr = dt.hour()
                                          if (hr < options.minHour)
                                              dt.hour(options.minHour)
                                          if (hr > options.maxHour)
                                              dt.hour(options.maxHour).minute(0)
                                      }
                                      scope.currentDate = dt.clone();
                                      scope.selectedDay = scope.currentDate.month() + '-' + scope.currentDate.date();
                                      if (!scope.modelSetted) {
                                          scope.modelSetted = true;
                                          fireChange()
                                          buildNew()
                                      }
                                      ngModel.$render();
                                      scope.modelDate = scope.currentDate.clone().toDate();
                                      if (options.autoHide && !options.timepicker)
                                          $picker.hide();
                                  });
                                  
                              }
                          })
                      }
                      
                      if (options.minDateFrom) {
                          var fromEl = angular.element(options.minDateFrom)
                          if (fromEl.length) {
                              var hasChage = false;
                              var fromPicker = fromEl.data('$datepicker');
                              var fromScope = fromPicker && fromPicker.$scope;
                              fromScope && fromScope.$watch('modelDate', function (newValue, oldValue) {
                                  if (newValue) {
                                      apply(function () {
                                          var dt = moment(newValue);
                                          scope.minDate = dt.clone().add(options.minRange, options.rangeType);
                                          scope.currentDate = dt.clone().add(options.defaultRange, options.rangeTypee);
                                          scope.selectedDay = scope.currentDate.month() + '-' + scope.currentDate.date();
                                          $picker.caches = {};
                                          options.minYear = scope.minDate.year();
                                          if (options.maxRange) {
                                              scope.maxDate = dt.clone().add(options.maxRange, options.rangeType);
                                              options.maxYear = scope.maxDate.year();
                                          }
                                          getYearArray()
                                          buildNew();
                                          fireChange();
                                          hasChage = true;
                                      })
                                  }

                              })
                              fromScope && fromScope.$on(options.prefixEvent + '.hide', function () {
                                  if (hasChage)
                                      $picker.show();
                                  hasChage = false;
                              });
                          }
                      }
                      if (options.iconId) {
                          var iconEl = angular.element(options.iconId)
                          if (iconEl.length) {
                              iconEl.on('click', function () {
                                  $picker.toggle();
                              })
                              scope.$on('$destroy', function () {
                                  iconEl.off('click')
                              });
                          }
                      }
                      scope.$watch('selectedIndex', function (newValue, oldValue) {
                          
                          if (newValue != oldValue) {
                              var idx = newValue;
                              if (idx >= scope.dayArray.length)
                                  idx = scope.dayArray.length - 1;
                              var dt = scope.dayArray[idx];
                              scope.selectedDay = dt.month + '-' + dt.day;
                              var diff = dt.month - scope.currentDate.month();
                              if (diff != 0) {
                                  if (diff > 0 && diff != 11 || diff == -11)
                                      $picker.next();
                                  else if (diff < 0 || diff == 11)
                                      $picker.before();
                              }
                              
                              scope.currentDate.date(dt.day);
                              scope.currentDate.month(dt.month);
                              fireChange('date');
                              renderModel();
                          }
                      })
                      
                      scope.$watch('currentDateObject.month', function (newval, oldval) {
                          if (newval != oldval && oldval) {
                              scope.selectedDay = scope.selectedDay.replace(oldval + '-', newval + '-');
                          }
                      })
                      scope.$on('pickerTimeChanged', function (evt, val) {
                          formatPicker();
                          if (angular.isFunction(options.onTimeChange))
                              options.onTimeChange(scope, { $currentDate: scope.currentDate.toDate() });
                          if (angular.isFunction(options.onChange))
                              options.onChange(scope, { $currentDate: scope.currentDate.toDate() });
                      })
                      scope.$on('pickerDatetimeChanged', function (evt, val) {
                          formatPicker();
                          if (angular.isFunction(options.onChange))
                              options.onChange(scope, { $currentDate: scope.currentDate.toDate() });
                      })
                      scope.$on('pickerDateChanged', function (evt, val) {
                          formatPicker();
                          if (angular.isFunction(options.onDateChange))
                              options.onDateChange(scope, { $currentDate: scope.currentDate.toDate() });
                          if (angular.isFunction(options.onChange))
                              options.onChange(scope, { $currentDate: scope.currentDate.toDate() });
                      })
                  }
                  function formatPicker() {
                      (options.timeView == 'list') && scrollTime();
                      scope.currentMonthTitle = scope.currentDate.format(options.headerFormat);
                      scope.currentYear = scope.currentDate.year();
                      options.showYears && scrollYear();
                  }
                  function apply(fn) {
                      if (!scope.$$phase) {
                          scope.$apply(function () {
                              fn();
                          })
                      }
                      else
                          fn();
                  }

                  return $picker;
              }
              return Factory;
          }
        ];
    })
    .directive('timePickerSwitch',
      function () {
          return {
              restrict: 'AC',
              link: function postLink(scope, element, attr, transclusion) {
                  var span = angular.element('<a href="#" class="tps-btn"></a>').append('<i class="' + scope.$eval(attr.timeIcon) + '"></i>').appendTo(element)
                  var time = angular.element('<span>Time</span>').appendTo(span)
                  scope.$on('pickerTimeChanged', function (evt, val) {
                      var format = scope.$options.timeView == 'list' ? 'HH:mm' : 'HH:mm:ss';
                      time.html(scope.currentDate.format(format))
                  })
                  element.on('click', function (evt) {
                      evt.preventDefault();
                      evt.stopPropagation();
                      if (scope.$options.datepicker)
                          scope.$toggleTimepicker();
                      else
                          scope.$apply(function () { scope.$hide() });

                  });
                  if (!scope.$options.datepicker)
                      scope.$$postDigest(function () {
                          scope.$toggleTimepicker();
                      });

                  element.append('<a class="tp-close" title="Close"><i class="' + scope.$eval(attr.closeIcon) + '"></i></a>');
                  scope.$on('$destroy', function () {
                      element.off('click')
                  });

              }
          };
      })
    .directive('tpBindTime',
      function () {
          return {
              restrict: 'AC',
              link: function postLink(scope, element, attr, transclusion) {
                  var type = attr.tpBindTime;
                  scope.$watch('currentDateObject.' + type, function (newVal, oldVal) {
                      switch (type) {
                          case 'hour':
                              element.html(scope.currentDate.format('HH'))
                              break;
                          case 'minute':
                              element.html(scope.currentDate.format('mm'))
                              break;
                          case 'second':
                              element.html(scope.currentDate.format('ss'))
                              break;
                      }
                  })
              }
          };
      })
    .directive('tpTimeListItem',
      function () {
          return {
              restrict: 'AC',
              link: function postLink(scope, element, attr, transclusion) {
                  var time = scope.time;
                  element.html('<span>' + time + '</span>');
                  element.on('click', function (evt) {
                      scope.$parent.$apply(function () {
                          scope.$parent.currentTimeString = time;
                          scope.$parent.$setTime(time);
                      })
                  })
                  scope.$on('$destroy', function () {
                      element.off('click')
                  });
              }
          };
      })
    .directive('calDateItem',
      function () {
          return {
              restrict: 'AC',
              link: function postLink(scope, element, attr, transclusion) {
                  var index = parseInt(attr.calDateItem);
                  var options = scope.$options;
                  if (!element.hasClass('unselectable'))
                      element.on('click', function (evt) {
                          evt.preventDefault();
                          scope.$parent.$apply(function () {
                              if (scope.selectedIndex != index)
                                  scope.selectedIndex = index;
                              else
                                  scope.$hide();
                          });
                      })
                  scope.$on('$destroy', function () {
                      element.off('click')
                  });

              }
          };
      }
    )
    .directive('nqDatepicker', ['$datepicker',
      function ($datepicker) {
          return {
              restrict: 'EAC',
              require: '?ngModel',
              link: function postLink(scope, element, attr, ngModel) {
                  var options = {
                      $scope : scope.$new()
                  }
                  if (angular.isDefined(attr.qoMode)) {
                      var mode = attr.qoMode;
                      if (/datetime|time/.test(mode)) {
                          options.timepicker = true;
                          if (!attr.qoFormat) {
                              if (mode == 'datetime')
                                  options.format = 'MM-DD-YYYY HH:mm:ss';
                              else {
                                  options.format = 'HH:mm:ss';
                                  options.datepicker = false;
                              }
                                  
                          }
                          else if (mode == 'time') {
                              options.datepicker = false;
                          }
                      }
                  }
                  var picker = new $datepicker(element, options, attr, ngModel);
                  element.data('$datepicker', picker)
                  scope.$on('$destroy', function () {
                      picker && picker.destroy();
                      options = null;
                      picker = null;
                  });

              }
          };
      }
    ])
}(window, window.angular);


'use strict';
angular.module('ngQuantum.dropdown', ['ngQuantum.popMaster'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';

        $templateCache.put('dropdown/dropdown.tpl.html',
          "<ul tabindex=\"-1\" class=\"dropdown-menu\" role=\"menu\"><li role=\"presentation\" ng-class=\"{divider: item.divider}\" ng-repeat=\"item in content\"><a role=\"menuitem\" tabindex=\"-1\" ng-href=\"{{item.href}}\" ng-if=\"!item.divider && item.href\" ng-bind=\"item.text\"></a> <a role=\"menuitem\" tabindex=\"-1\" href=\"javascript:void(0)\" ng-if=\"!item.divider && item.click\" ng-click=\"$parent.$eval(item.click);$hide();\" ng-bind=\"item.text\"></a></li></ul>"
        );

    }])
    .provider('$dropdown', function () {
        var defaults = this.defaults = {
            effect: 'flip-x',
            typeClass: 'dropdown',
            prefixEvent: 'dropdown',
            placement: 'bottom-left',
            template: 'dropdown/dropdown.tpl.html',
            trigger: 'click',
            directive: 'nqDropdown',
            instanceName: 'dropdown',
            ensurePlacement:true,
            showArrow: false,
            fireEmit: true,
            displayReflow: false,
            keyboard: true,
            fixWidth:true
        };
        this.$get = [
          '$timeout',
          '$rootScope',
          '$popMaster', '$helpers',
          function ($timeout, $rootScope, $popMaster, $helpers) {

              function DropdownFactory(element, config, attr) {
                  var $dropdown = {};
                  config = angular.extend(config, $helpers.parseOptions(attr, config))
                  var options = angular.extend({}, defaults, config);
                  if (!options.independent) {
                      var target;
                      if (options.target)
                          target = angular.element(options.target);
                      else {
                          target = angular.element(element.find('.dropdown-container, .dropdown-menu')[0]);
                          if (target.length < 1)
                              target = angular.element(element.next('.dropdown-container, .dropdown-menu')[0]);
                      }

                      if (target.length > 0)
                          options.targetElement = target
                  }

                  $dropdown = new $popMaster(element, options);
                  options = $dropdown.$options = $helpers.observeOptions(attr, $dropdown.$options);
                  var scope = $dropdown.$scope
                  $dropdown.$onKeyDown = function (e) {
                      if (!/(38|40|13)/.test(e.keyCode))
                          return;
                      e.preventDefault();
                      e.stopPropagation();

                      var $items = $dropdown.$target.find('[role="menuitem"]:visible');
                      $dropdown.$target.focus();
                      if (!$items.length) return;
                      var index = scope.lastIndex > -1 ? scope.lastIndex : -1
                      if (e.keyCode == 38 && index > 0) index--                  // up
                      if (e.keyCode == 40 && index < $items.length - 1) index++  // down
                      if (!~index) index = 0
                      if (e.keyCode === 13) {
                          return angular.element($items[index]).trigger('click');
                      }
                      $items.eq(index).focus()
                      scope.lastIndex = index;

                  };
                  var show = $dropdown.show;
                  $dropdown.show = function (callback) {
                      var promise = show(callback);
                      angular.element(document).off('keydown.nqDropdown.api.data');
                      angular.element(document).on('keydown.nqDropdown.api.data', $dropdown.$onKeyDown);

                      if (!scope.$$phase) {
                          scope.$apply(function () {
                              $dropdown.$target.focus();
                          })
                      }
                      else
                          $dropdown.$target.focus();
                      if (!options.independent && options.fixWidth) {
                          var ew = element.outerWidth(true), tw = $dropdown.$target.outerWidth(true);
                          if(ew > tw)
                              $dropdown.$target.css('min-width', ew)
                      }
                      element.parent().addClass('open')
                      return promise;
                  };
                  var hide = $dropdown.hide;
                  $dropdown.hide = function (callback) {
                      scope.lastIndex = -1;
                      angular.element(document).off('keydown.nqDropdown.api.data');
                      element.parent().removeClass('open')
                     return hide(callback);
                  };
                  if (attr && angular.isDefined(options.directive)) {
                      attr[options.directive] && options.$scope.$watch(attr[options.directive], function (newValue, oldValue) {
                          scope.content = newValue;
                      }, true);
                  }
                  

                  if (options.autoDestroy)
                      scope.$on('$destroy', function () {
                          $dropdown && $dropdown.destroy();
                          $dropdown = null

                      })
                  return $dropdown;
              }
              return DropdownFactory;
          }
        ];
    })
    .directive('nqDropdown', ['$dropdown', 'templateHelper',
      function ($dropdown, templateHelper) {
          return {
              restrict: 'EA',
              link: function postLink(scope, element, attr, transclusion) {
                  var options = {
                      $scope: scope.$new()
                  };
                  
                  options.uniqueId = attr.qoUniqueId || attr.id || options.$scope.$id;
                  if (attr.qoTrigger && attr.qoTrigger.indexOf('hover') > -1) {
                      options.holdHoverDelta = true;
                      options.delayHide = 100;
                      options.delayShow = 10;
                  }

                  var dropdown = {};
                  if (angular.isDefined(attr.qoIndependent)) {
                      options.independent = true;
                      options.html = true;
                      options.displayReflow=false;
                      options.targetElement = element;
                      options.fireEmit = true;
                      dropdown = new $dropdown(null, options, attr);

                  }
                  else
                      dropdown = new $dropdown(element, options, attr);

                  scope.$on('$destroy', function () {
                      dropdown = null;
                  })
                  element.data('$nqDropdown', dropdown)

              }
          };
      }
    ])

'use strict';
angular.module('ngQuantum.loading', ['ngQuantum.services.lazy'])
    .run(['$http', '$rootScope', '$timeout', function ($http, $rootScope, $timeout) {
        $rootScope.$watch(function () { return $http.pendingRequests.length }, function (newVal, oldVal) {
            $rootScope.$pendingRequestCount = $rootScope.$pendingRequestCount || 0;
            $timeout(function() {
                $rootScope.$pendingRequestCount = $rootScope.$pendingRequestCount + (newVal-oldVal);
            },0)
        })
        
    }])
    .provider('$loading', function () {
        var defaults = this.defaults = {
            placement: 'top',
            container: 'body',
            backdrop: false,
            timeout: 2000,
            delayHide: 500,
            theme: false,
            showBar: true,
            showSpinner: true,
            spinnerIcon: '<i class="fic spin-icon fu-spinner-fan spin"></i>',
            busyText: 'Loading...'
        };
        this.$get = ['$timeout', '$rootScope', '$compile', '$http',
          function ($timeout, $rootScope, $compile, $http) {
              function LoadingFactory(config, theme, placement) {
                  var $loading = {};
                  if (angular.isString(config)) {
                      config = {
                          busyText: config,
                          theme: theme,
                          placement: placement
                      }
                  }
                  var options = $loading.$options = angular.extend({}, defaults, config);
                  var container = angular.isElement(options.container) ? options.container : angular.element(options.container)
                  if (!container.length)
                      container = angular.element('body');
                  var scope = $loading.$scope = options.$scope || $rootScope.$new(), cancel;

                  var template = angular.element(getTemplate());
                  var place = options.container == 'body' ? 'prepend' : 'append';
                  $compile(template)(scope);
                  $timeout(function () {
                      container[place](template);
                  }, 0)
                  
                  scope.busyText = options.busyText;
                  if (options.theme) {
                      scope.loadingTheme = 'loading-' + options.theme;
                      scope.progressTheme = 'progress-bar-' + options.theme;
                  }
                  scope.showBar = options.showBar;
                  scope.showSpinner = options.showSpinner;
                  scope.currentRate = 0;
                  if (options.placement)
                      template.addClass('loading-' + options.placement)
                  $loading.show = function () {
                      template.css('display', 'block')
                      $loading.isShown = true;
                      if (options.showBar)
                          $timeout(function () {
                              scope.currentRate = 0;
                              $loading.updateProgress();
                          }, 0)
                          
                      options.timeout !== false &&
                      $timeout(function () {
                          $loading.hide();
                      }, options.timeout)
                  };
                  $loading.hide = function () {
                      if (!$loading.isShown)
                          return;
                      scope.currentRate = 100;
                      $timeout(function () {
                          template.css('display', 'none')
                          scope.currentRate = 0;
                          $loading.isShown = false;
                      }, options.delayHide)

                  };
                  $loading.updateProgress = function (rate) {
                      if (!$loading.isShown || $http.$pendingRequestCount > 0)
                          return;
                      if (rate)
                          scope.currentRate = rate;
                      else {
                          if (scope.currentRate < 100)
                              scope.currentRate = scope.currentRate + (scope.currentRate < 80 ? 5 : (parseInt(100 - scope.currentRate) / 2));
                       $timeout(function () {
                              if (scope.currentRate < 99)
                                  $loading.updateProgress();
                          }, 20)
                      }
                  };
                  scope.$on('$destroy', function () {
                      $loading = null;
                  });
                  $rootScope.$watch('$pendingRequestCount', function (newVal, oldVal) {
                      if (newVal <= 0) {
                          $http.$pendingRequestCount = 0;
                          $timeout(function () {
                              $loading.hide();
                          }, 10)
                      }
                      else {
                      }

                  })
                  function getTemplate() {
                      var html = '<div class="loading-container"  ng-class="loadingTheme">'
                                    + '<div class="progress" ng-show="showBar">'
                                    + '<div class="progress-bar active" ng-class="progressTheme" role="progressbar" ng-style="{\'width\':currentRate + \'%\'}" aria-valuenow="{{currentRate}}" aria-valuemin="0" aria-valuemax="100">'
                                    + '</div>'
                                    + '</div>'
                                    + '<div class="spinner-container">'
                                        + '<div class="busy-text">'+ options.spinnerIcon +' {{busyText}}</div>'
                                    + '</div>'
                                + '</div>'
                                + ''
                                + '';
                      return html;
                  }
                  return $loading;
              }
              return LoadingFactory;
          }
        ];
    })
'use strict';
angular.module('ngQuantum.loadingButton', ['ngQuantum.services.helpers'])
    .provider('$loadingButton', function () {
        var defaults = this.defaults = {
            timeout: 2000,
            onError: angular.noop,
            onSuccess: angular.noop,
            loadingText: 'Loading...',
            showIcons: true,
            spinner: '<i class="fic fu-spinner-circle spin"></i> ',
            successIcon: '<i class="fic fu-check  flash"></i>',
            errorIcon: '<i class="fic fu-cross-c flash red"></i> ',
            timeoutIcon: '<i class="fic fu-bell-off"></i> '
        };
        this.$get = function () {
            return { defaults: defaults };
        };
    })
    .directive("nqLoadingButton", ['$parse', '$loadingButton', '$helpers', '$timeout', '$q',
        function ($parse, $loadingButton, $helpers, $timeout, $q) {
            return {
                restrict: 'A',
                link: function (scope, element, attr) {
                    var fn = $parse(attr.nqLoadingButton);
                    var options = angular.extend({}, $loadingButton.defaults);
                    angular.forEach(['onSuccess', 'onTimeout', 'onError'], function (key) {
                        if (angular.isDefined(attr[key]))
                            options[key] = $parse(attr[key]);
                    })
                    angular.forEach(['loadingText', 'showIcons', 'timeout'], function (key) {
                        angular.isDefined(attr[key]) && (options[key] = $helpers.parseConstant(attr[key]));
                    })
                    var cloneElement = element.clone();
                    cloneElement.attr('disabled', 'disabled').html(options.loadingText);

                    options.showIcons && cloneElement.prepend(options.spinner);
                    var erricon, timeicon, successicon;
                    if (options.showIcons) {
                        successicon = angular.isElement(options.successIcon) ? options.successIcon : angular.element(options.successIcon)
                        erricon = angular.isElement(options.errorIcon) ? options.errorIcon : angular.element(options.errorIcon)
                    }
                    element.on('click', function (event) {
                        scope.$apply(function () {
                            getTimer(event);
                        });
                    });

                    function getTimer(event) {
                        element.css('display', 'none');
                        element.after(cloneElement);
                        $q.when(fn(scope, { $event: event }))
                        .then(function (res) {
                            element.css('display', '');
                            cloneElement.remove();
                            successicon && element.prepend(successicon);
                            successicon && setTimeout(function () {
                                successicon.remove();
                            }, options.timeout)
                            options.onSuccess(scope, { $event: event, $data: res });
                            return res;
                        }, function (res) {
                            element.css('display', '');
                            cloneElement.remove();
                            erricon && element.prepend(erricon);
                            options.onError(scope, { $event: event, $data: res });
                            erricon && setTimeout(function () {
                                erricon.remove();
                            }, options.timeout)
                        });
                    }
                }
            }
        }]);
'use strict';
angular.module('ngQuantum.modal', ['ngQuantum.popMaster'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('modal/modal.tpl.html',
          '<div class="modal" tabindex="-1" role="dialog"><div class="modal-dialog"><div class="modal-content"><div class="modal-header" ng-show="title"><h4 class="modal-title" ng-bind="title"></h4></div><div class="modal-body"  ng-bind="content"></div><div class="modal-footer"><button type="button" class="btn btn-default" ng-click="$hide()">{{closeText}}</button></div><button type="button" class="close" ng-click="$hide()" ng-bind-html="closeIcon">&nbsp;</button></div></div></div>'
        );
        $templateCache.put('modalbox/alertbox.tpl.html',
          '<div class="modal" tabindex="-1" role="dialog"><div class="modal-dialog"><div class="modal-content"><div class="modal-header" ng-show="title"><h4 class="modal-title" ng-bind="title"></h4></div><div class="modal-body"><div class="modal-body-inner" ng-bind="content"></div></div><div class="modal-footer"><button type="button" class="btn btn-primary" ng-click="$hide()">{{okText}}</button></div><button type="button" class="close" ng-click="$hide()" ng-bind-html="closeIcon">&nbsp;</button></div></div></div>'
        );
        $templateCache.put('modalbox/confirmbox.tpl.html',
        '<div class="modal" tabindex="-1" role="dialog"><div class="modal-dialog"><div class="modal-content"><div class="modal-header" ng-show="title"><h4 class="modal-title" ng-bind="title"></h4></div><div class="modal-body"><div class="modal-body-inner" ng-bind="content"></div></div><div class="modal-footer"><button type="button" class="btn btn-primary" ng-click="$cancel()">{{cancelText}}</button> <button type="button" class="btn btn-success" ng-click="$confirm()">{{confirmText}}</button></div><button type="button" class="close" ng-click="$cancel()" ng-bind-html="closeIcon">&nbsp;</button></div></div></div>'
        );
        $templateCache.put('modalbox/promptbox.tpl.html',
          '<div class="modal" tabindex="-1" role="dialog"><div class="modal-dialog"><div class="modal-content"><div class="modal-header" ng-show="title"><h4 class="modal-title" ng-bind="title"></h4></div><div class="modal-body"><div class="modal-body-inner" ng-bind="content"></div><div class="margin-t form-group"><label for="promptModel">{{promptLabel}}</label><input type="text" class="form-control" name="promptModel" ng-model="promptModel"></div></div><div class="modal-footer"><button type="button" class="btn btn-primary" ng-click="$cancel()">{{cancelText}}</button> <button type="button" class="btn btn-success" ng-click="$confirm()">{{confirmText}}</button></div><button type="button" class="close" ng-click="$cancel()" ng-bind-html="closeIcon">&nbsp;</button></div></div></div>'
          );
    }])
        .provider('$modal', function () {
            var defaults = this.defaults = {
                effect: 'from-top',
                backdropEffect: 'fade-in',
                animateTarget: '.modal-dialog',
                typeClass: 'modal',
                prefixEvent: 'modal',
                directive: 'nqModal',
                placement: 'near-top',
                uniqueId: 'nq-modal',
                trigger: 'click',
                clearExists: false,
                template: 'modal/modal.tpl.html',
                contentTemplate: false,
                container: false,
                element: null,
                backdrop: true,
                keyboard: true,
                closeText: 'Close',
                closeIcon: '<i class="fic fu-cross"></i>',
                buildOnShow: true,
                html: false,
                size: false,
                displayReflow: false,
                show: false,
                autoDestroy:false
            };
            this.$get = ['$window', '$compile', '$http', '$sce', '$timeout', '$helpers', '$popMaster',
              function ($window, $compile, $http, $sce, $timeout, $helpers, $popMaster) {
                  var $animate = $helpers.injectModule('$animate', 'ngAnimate');
                  var forEach = angular.forEach;
                  var bodyElement = angular.element($window.document.body);
                  function ModalFactory(config, attr) {

                      var $modal = {}, element = config.element;
                      if (!config.$scope) {
                          config.autoDestroy = true;
                          config.show = true;
                          config.html = true;
                          config.fireEmit = true;
                      }
                      if (attr)
                          config = $helpers.parseOptions(attr, config);
                      var options = config = angular.extend({}, defaults, config);
                      
                      
                      
                      options.container = 'body';
                      options.preventReplace = true;
                      $modal = new $popMaster(element, options);
                      if (attr)
                          options = $modal.$options = $helpers.observeOptions(attr, $modal.$options);
                      else
                          options = $modal.$options;
                      
                      var scope = $modal.$scope
                      config.content && (scope.content = config.content)
                      config.title && (scope.title = config.title)
                      scope.closeText = options.closeText;
                      scope.closeIcon = options.closeIcon;

                      var backdropElement = angular.element('<div class="' + options.typeClass + '-backdrop"/>');

                      var init = $modal.init;
                      $modal.init = function () {
                          init();
                          $modal.$promise.then(function (contentTemplate) {
                              if (options.backdrop) {
                                  backdropElement.prependTo($modal.$target)
                              }
                              if (options.screenMode) {
                                  $modal.$target.addClass('screen-mode')
                              }
                              else if ($modal.$animateTarget && options.size)
                                  $modal.$animateTarget.addClass('modal-' + options.size)

                              $modal.footerCheck(contentTemplate);
                              headerCheck(contentTemplate);
                              if (options.trigger == 'hover') {
                                  element.off('mouseleave', $modal.leave);
                              }
                          })
                          
                      };
                      var destroy = $modal.destroy;
                      $modal.destroy = function () {
                          destroy();
                          if (backdropElement) {
                              backdropElement.off('click')
                              backdropElement.remove();
                              backdropElement = null;
                          }
                      };
                      var show = $modal.show;
                      $modal.show = function () {
                         var promise = show();
                          if (options.backdrop) {
                              if (options.backdropEffect) {
                                  backdropElement.addClass('in');
                                  backdropElement.show();
                              }
                              options.backdrop !== 'static' && backdropElement.on('click', hideOnBackdropClick);
                          }
                          if (options.trigger == 'hover') {
                              $helpers.unBindTriggers(element, 'hover', $modal)
                          }
                          if ($modal.$animateTarget && options.size)
                              $modal.$animateTarget.addClass('modal-' + options.size);
                          
                          setTimeout(function () {
                              resizeModal();
                          }, 0);
                          return promise;
                      };
                      var hide = $modal.hide;
                      $modal.hide = function () {
                          if (options.backdrop) {
                              if (options.backdropEffect) {
                                  backdropElement.addClass('fade')
                                  backdropElement.removeClass('in')
                                  
                                  
                              }
                              options.backdrop !== 'static' && backdropElement && backdropElement.off('click');

                          }
                          if (options.trigger == 'hover' && element) {
                              $helpers.bindTriggers(element, 'hover', $modal)
                          }
                          var promise = hide();
                          promise.then(function () {
                              if ($modal.$animateTarget && options.size)
                                  $modal.$animateTarget.removeClass('modal-' + options.size);

                              clearHeight();
                              options.autoDestroy && $modal && $modal.destroy();
                          });
                          return promise;
                          
                      };
                      function hideOnBackdropClick(evt) {
                          options.backdrop === 'static' ? $modal.focus() : $modal.hide();
                      }
                      $modal.footerCheck = footerCheck;
                      function footerCheck(contentTemplate) {
                          var customFooter = $modal.$target.find('.custom-footer');
                          if (!customFooter.length && options.htmlObject)
                              customFooter = scope.content.find('.custom-footer');
                          if (!customFooter.length && contentTemplate && contentTemplate.find)
                              customFooter = contentTemplate.find('.custom-footer');
                          var footer = $modal.$target.find('.modal-footer');
                          if (customFooter.length && footer.length) {
                              footer.replaceWith(customFooter.addClass('modal-footer'))
                              $modal.customFooter = customFooter;
                          }
                      };
                      function headerCheck(contentTemplate) {
                          var customHeader = $modal.$target.find('.custom-header');
                          if (!customHeader.length && options.htmlObject)
                              customHeader = scope.content.find('.custom-header');
                          if (!customHeader.length && contentTemplate && contentTemplate.find)
                              customHeader = contentTemplate.find('.custom-header');
                          var header = $modal.$target.find('.modal-header');
                          if (customHeader.length && header.length) {
                              scope.title = true;
                              header.replaceWith(customHeader.addClass('modal-header'))
                          }
                      };
                      if (attr) {
                          angular.forEach(['title', 'content'], function (key) {
                              var akey = 'qs' + key.capitaliseFirstLetter();
                              attr[akey] && (scope[key] = $sce.trustAsHtml(attr[akey]));
                              attr.$$observers && attr.$$observers[akey] && attr.$observe(akey, function (newValue, oldValue) {
                                  scope[key] = $sce.trustAsHtml(newValue);
                              });
                          });
                          if (angular.isDefined(options.directive)) {
                              attr[options.directive] && options.$scope.$watch(attr[options.directive], function (newValue, oldValue) {
                                  if (angular.isObject(newValue)) {
                                      if (angular.isArray(newValue))
                                          scope.content = newValue;
                                      else
                                          angular.extend(scope, newValue);
                                  } else {
                                      scope.content = newValue;
                                  }
                              }, true);
                          }
                          
                      }
                      
                      
                      function resizeModal() {
                          if (!$modal.$target) {
                              setTimeout(function () {
                                  resizeModal();
                              }, 10);
                              return false;
                          }
                          var cnt = $modal.$target.find('.modal-content'),
                          bdy = $modal.$target.find('.modal-body'),
                          hdr = $modal.$target.find('.modal-header'),
                          ftr = $modal.$target.find('.modal-footer'),
                          dialog = $modal.$target.find('.modal-dialog');
                          if (options.screenMode) {
                              fixBodyHeight(cnt, hdr, ftr);
                          }
                          else {
                              var mh = $modal.$target.innerHeight(),
                                  dh = dialog.outerHeight(true);
                              if (dh > mh) {
                                  $modal.$target.addClass('modal-fix-height');
                                  fixBodyHeight(cnt, hdr, ftr);
                              } else {
                                  verticalPlacement(dialog, mh - dialog.innerHeight())
                              }
                          }
                      }
                      function fixBodyHeight(cnt, hdr, ftr) {
                          var hh = hdr.length ? hdr.outerHeight(true) : 0,
                          fh = ftr.length ? ftr.outerHeight(true) : 0;
                          cnt.css({ 'padding-top': hh, 'padding-bottom': fh });
                          hdr.css('margin-top', -hh);
                      }
                      function clearHeight() {
                          $modal.$target.removeClass('modal-fix-height');
                          $modal.$target.find('.modal-content').css({ 'padding-top': '', 'padding-bottom': '' });
                          $modal.$target.find('.modal-header').css('margin-top', '');
                          $modal.$target.find('.modal-dialog').css('top', '');
                      }
                      function verticalPlacement(dialog, diff) {
                          if (diff > 0) {
                              var top = 0;
                              switch (options.placement) {
                                  case 'center':
                                      top = diff / 2
                                      break;
                                  case 'bottom':
                                      top = diff
                                      break;
                                  case 'near-top':
                                      top = diff / 3
                                      break;
                                  case 'near-bottom':
                                      top = (diff / 3) * 2
                                      break;
                                  default:
                                      top = 0
                              }
                              dialog.css('top', top);
                          }
                      }
                      scope.$on('$destroy', function () {
                          $modal && !$modal.isDestroyed && $modal.destroy();
                          $modal = null;
                      });
                      return $modal;
                  }
                  return ModalFactory;
              }
            ];
        })
    .directive('nqModal', ['$modal',
      function ($modal) {
          return {
              restrict: 'EAC',
              scope: true,
              link: function postLink(scope, element, attr, transclusion) {
                  var options = {
                      $scope: scope
                  };
                  options.uniqueId = attr.qoUniqueId || attr.id || scope.$id;
                  var modal = {}
                  if (angular.isDefined(attr.qoIndependent)) {
                      options.htmlObject = true;
                      scope.content = element;
                      options.buildOnShow = false;
                      modal = $modal(options, attr);
                  }
                  else {
                      options.element = element;
                      options.html = true;
                      modal = $modal(options, attr);

                  }
                  element.data('$nqModal', modal)
              }
          };
      }
    ])
    .directive('modalBodyInner', function () {
        return {
            restrict: 'C',
            require: '?nqModal',
            link: function postLink(scope, element, attr, controller) {
                element.on('scroll', function (e) {
                    scope.$broadcast('staticContentScroll', this.scrollTop)
                })
            }
        };
    })

'use strict';
angular.module('ngQuantum.modalBox', ['ngQuantum.modal'])
        .provider('$modalBox', function () {
            var defaults = this.defaults = {
                effect: 'slit',
                boxType: 'alert',
                typeClass: 'modalbox',
                instanceName: 'modal',
                prefixEvent: 'modalbox',
                directive: 'nqModalBox',
                placement: 'near-top',
                uniqueId: 'nq-modalbox',
                trigger: 'click',
                okText: 'OK',
                cancelText: 'Cancel',
                confirmText: 'Confirm',
                template:false,
                showIcon: true,
                promptModel: '$promptValue',
                alertTemplate: 'modalbox/alertbox.tpl.html',
                confirmTemplate: 'modalbox/confirmbox.tpl.html',
                promptTemplate: 'modalbox/promptbox.tpl.html'
            };
            this.$get = ['$modal', '$parse', '$helpers',
              function ($modal, $parse, $helpers) {
                  function ModalBoxFactory(config, attr) {
                      findTemplate()
                      var $modalBox = {}, element = config.element, $buttons;

                      var options = angular.extend({}, defaults, config);
                      attr && angular.forEach(['afterOk', 'afterConfirm', 'afterCancel', 'afterCustom'], function (key) {
                          if (angular.isDefined(attr[key])) {
                              options[key] = $parse(attr[key]);
                          }
                      })
                      $modalBox = new $modal(options, attr);
                      options = config = $modalBox.$options;
                      var scope = $modalBox.$scope
                      angular.forEach(['okText', 'cancelText', 'confirmText', 'promptLabel'], function (key) {
                          scope[key] = options[key]

                      })
                      var init = $modalBox.init;
                      $modalBox.init = function () {
                          init();
                          if (!options.showIcon) {
                              $modalBox.$target.addClass('no-icon')
                          }
                      };
                      var show = $modalBox.show;
                      $modalBox.show = function () {
                          if (options.boxType == 'prompt')
                              scope.promptModel = '';
                          var promise = show();
                          if ($buttons)
                              $buttons.on('click', $modalBox.hide);
                          return promise;
                      };
                      var hide = $modalBox.hide;
                      $modalBox.hide = function () {

                          if (angular.isFunction(options.afterOk) && !$buttons) {
                              options.afterOk(scope)
                          }
                          if ($buttons) {
                              if (angular.isFunction(options.afterCustom))
                                  options.afterCustom(scope)
                              $buttons.off('click', $modalBox.hide)
                          }
                          return hide();
                      };
                      var footerCheck = $modalBox.footerCheck;
                      $modalBox.footerCheck = function () {
                          footerCheck(arguments);
                          if ($modalBox.customFooter && $modalBox.customFooter.length)
                              $buttons = $modalBox.customFooter.find('button');
                      };
                      scope.$confirm = function () {
                          scope.$$postDigest(function () {
                              $modalBox.hide();
                              if (angular.isFunction(options.afterConfirm)) {
                                  scope.$parent.$apply(function () {
                                      if (options.boxType == 'prompt')
                                          scope.$parent[options.promptModel] = scope.promptModel;
                                  })
                                  options.afterConfirm(scope);
                              }
                          });

                      }
                      scope.$cancel = function () {
                          scope.$$postDigest(function () {
                              $modalBox.hide();
                              if (angular.isFunction(options.afterCancel)) {
                                  options.afterCancel(scope)
                              }
                          });

                      }
                      scope.$on('$destroy', function () {
                          $modalBox && !$modalBox.isDestroyed && $modalBox.destroy();
                          $modalBox = null;
                      });
                      function findTemplate() {

                          switch (config.boxType) {
                              case 'alert':
                                  config.template = config.alertTemplate || defaults.alertTemplate
                                  break;
                              case 'confirm':
                                  config.template = config.confirmTemplate || defaults.confirmTemplate
                                  break;
                              case 'prompt':
                                  config.template = config.promptTemplate || defaults.promptTemplate
                                  break;
                              default:
                                  config.template = config.template || defaults.alertTemplate
                                  break;
                          }
                      }
                      return $modalBox;
                  }
                  return ModalBoxFactory;
              }
            ];
        })
    .directive('nqModalBox', ['$modalBox','$helpers',
      function ($modalBox, $helpers) {
          return {
              restrict: 'EAC',
              scope:true,
              link: function postLink(scope, element, attr, transclusion) {
                  var options = {
                      $scope: scope
                  };
                  angular.forEach(['boxType', 'promptLabel', 'promptModel', 'alertTemplate', 'confirmTemplate', 'promptTemplate',
                      'showIcon', 'okText', 'cancelText', 'confirmText'], function (key) {
                      if (angular.isDefined(attr[key]))
                          options[key] = $helpers.parseConstant(attr[key]);

                  })
                  options.uniqueId = attr.uniqueId || attr.id || scope.$id;
                  options.element = element;
                  var modalBox = {}
                  if (angular.isDefined(attr.contentTarget)) {
                      var content = angular.element(attr.contentTarget)
                      if (!content.length) {
                          content = angular.element('<span><span class="label label-warning">Warning :</span> No content element find</span>')
                      }
                      options.htmlObject = true;
                      options.buildOnShow = false;
                      scope.content = content;
                      modalBox =new $modalBox(options, attr);
                  }
                  else {
                      options.element = element;
                      options.html = true;
                      modalBox =new $modalBox(options, attr);

                  }
                  scope.$on('$destroy', function () {
                      modalBox = null;
                  })
                  element.data('$nqModalBox', modalBox)
              }
          };
      }
    ])

+function (window, angular, undefined) {
    var props = ['placement', 'delayShow', 'delayHide', 'effect', 'speed', 'theme', 'showArrow', 'holdHoverDelta'];
    var app  = angular.module('ngQuantum.popMaster', ['ngQuantum.services', 'ngQuantum.directives'])
        .provider('$popMaster', function () {
            var defaults = this.defaults = {
                effect: 'fade-in',
                speed: 'fastest',
                typeClass: 'pop',
                prefixEvent: 'pop',
                fireEmit: false,
                fireBroadcast: false,
                container: false,
                placement: 'top',
                offsetTop: 0,
                offsetLeft: 0,
                targetElement: false,
                template: angular.element('<div style="min-width:100px; padding:3px; border:1px; solid #aaa">You should prepare a content will replace here...</div>'),
                contentTemplate: false,
                trigger: 'hover focus',
                keyboard: false,
                html: false,
                show: false,
                clearExists: true,
                autoDestroy: true,
                displayReflow: true,
                theme: false,
                delayShow: 0,
                delayHide:0

            }
            this.$get = ['$window', '$rootScope', '$compile', '$parse', '$http', '$timeout', '$animate', '$placement', '$helpers', 'templateHelper','$q',
              function ($window, $rootScope, $compile, $parse, $http, $timeout, $animate, $placement, $helpers, templateHelper, $q) {
                  var trim = String.prototype.trim;
                  var isTouch = $helpers.isTouch();
                  var htmlReplaceRegExp = /ng-bind="/gi;
                  var $$rAF = $helpers.injectModule('$$rAF', 'ngAnimate');
                  function MasterFactory(element, config) {
                      var $master = {};
                      var reopen = false;
                      $master.$currentElement = undefined;
                      var options = $master.$options = config = angular.extend({}, defaults, config);
                      var lastplacement = options.placement;
                      var scope = $master.$scope = options.$scope || $rootScope.$new();
                      options.delayShow = $helpers.ensureNumber(options.delayShow),
                          options.delayHide = $helpers.ensureNumber(options.delayHide);
                      if (angular.isDefined(options.onShow) || angular.isDefined(options.onHide))
                          options.fireBroadcast = options.fireEmit = true;
                      if (!options.instanceName)
                          options.instanceName = options.typeClass
                      var originalOptions = $master.$originalOptions = angular.extend({}, options);
                      isTouch && (options.keyboard = false);
                      angular.forEach(['hide', 'show', 'toggle'], function (value) {
                          scope['$' + value] = function () {
                              scope.$$postDigest(function () {
                                  $master[value]();
                              });
                          }
                      })
                      $master.$isShown = scope.$isShown = false;
                      var timeout, hoverState, linker, $target, $container, $animateTarget, shouldCompile;


                      options.hasClick = false;
                      $master.init = function () {
                          if (element && options.trigger) {
                              $helpers.unBindTriggers(element, options.trigger, $master);
                              options.hasClick = $helpers.bindTriggers(element, options.trigger, $master);
                          }
                          if (!options.buildOnShow || options.show)
                              build();
                          if (options.show) {
                              scope.$$postDigest(function () {
                                  options.trigger === 'focus' && element ? element.focus() : $master.show();
                              });
                          }

                      }
                      function start() {
                          if (!options.buildOnShow || options.show) {
                              if (options.targetElement) {
                                  $master.$promise = templateHelper.fetchContent(options.targetElement);
                              }
                              else {
                                  if (angular.isElement(options.template))
                                      $master.$promise = templateHelper.fetchContent(options.template);
                                  else if (options.template.indexOf('.html') > -1)
                                      $master.$promise = templateHelper.fetchTemplate(options.template);
                                  else
                                      $master.$promise = templateHelper.fetchContent(angular.element(options.template));
                                  shouldCompile = true;
                              }
                              if (options.contentTemplate) {
                                  $master.$promise = templateHelper.fetchContentTemplate($master)
                                  shouldCompile = true;
                              }
                              $master.$promise.then(function (template) {
                                  if (angular.isElement(template))
                                      linker = template;
                                  else {
                                      if (options.html)
                                          template = template.replace(htmlReplaceRegExp, 'ng-bind-html="');
                                      if (options.htmlObject)
                                          template = template.replace(/ng-bind="content"/gi, 'nq-bind="content"')
                                                             .replace(/ng-bind-html="content"/gi, 'nq-bind="content"');
                                      linker = trim.apply(template);
                                  }
                                  options.buildOnShow = false;
                                  $master.init();
                              });
                          }
                          else
                              $master.$promise = $q.when($master.init());

                          if(element && options.readonly)
                              element.attr('readonly', true)
                      }

                      $master.destroy = function () {
                          $master.isDestroyed = true;
                          angular.element('body').off('click', onBodyClick);
                          if (element && options.trigger)
                              $helpers.unBindTriggers(element, options.trigger, $master);
                          if ($target) {
                              $target.off();
                              $target.remove();
                              $target = null;
                          }
                          !options.$scope && scope.$destroy();
                      };
                      $master.enter = function () {
                          var promise;
                          if (this !== $master)
                              $master.$currentElement = angular.element(this);
                          clearTimeout(timeout);
                          hoverState = 'in';
                          if (!options.delayShow) {
                              return $master.show();
                          }
                          timeout = setTimeout(function () {
                              if (hoverState === 'in')
                                  promise =   $master.show();
                          }, options.delayShow);
                          return promise;
                      };
                      $master.show = function (callback) {
                          var lasttheme;
                          var promise;
                          if (options.buildOnShow) {
                              options.show = true;
                              options.buildOnShow = false;
                              start();
                              return false;
                          }
                          options = $master.$options;
                          if (($master.$isShown || $master.$isShowing || $master.$isHidding))
                              return false;
                          if (options.clearExists)
                              $master.clearExists();
                          element = $master.$currentElement || element;
                          var modal;
                          if (element)
                              modal = element.closest('.modal');
                          if (modal && modal.length)
                              $container = modal;
                          var parent = $container ? $container : null;

                          var after = $container ? angular.element(parent[0].lastChild) : element;
                          if (after && after.length < 1)
                              after = null;
                          if (!$target || $target.length < 1)
                              build();
                          else
                              ensureFixedPlacement();
                          if (options.theme) {
                              $target.removeClass(lasttheme);
                              lasttheme = options.instanceName + '-' + options.theme;
                              $target.addClass(lasttheme);
                          }

                          if (angular.isFunction($master['beforeShow'])) {
                              $master['beforeShow'](element, $target)
                          }
                          $target.removeClass(lastplacement);
                          lastplacement = options.placement;
                          $target.css({ display: 'block', top: '', left: '' }).addClass(lastplacement);
                          $target.removeClass('with-arrow');

                          $master.$isShowing= true;
                          if (options.effect) {
                              if (options.displayReflow) {
                                  $target.addClass(options.effect).addClass(options.speed);
                                  if (options.effect.indexOf('collapse') > -1)
                                      $target.height($target.outerHeight());
                                  
                                  promise = $animate.enter($target, parent, after).then(function () {
                                      complateShow(callback)
                                      $master.fireEvents('show');
                                      $master.$isShowing = false;
                                      $timeout(function () {
                                          $master.$isShown = scope.$isShown = true;
                                      }, 0)
                                  });
                                  $$rAF && $$rAF($master.$applyPlacement);
                                  

                              }
                              else {
                                  $animateTarget.removeClass('ng-animate').removeClass(options.speed).removeClass(options.effect + '-remove').removeClass(options.effect + '-remove-active');
                                  $master.$applyPlacement();
                                  $animateTarget.addClass(options.speed);
                                  if (options.effect.indexOf('collapse') > -1)
                                      $animateTarget.height($target.outerHeight());

                                  $animateTarget.css('display', 'block');
                                  $animateTarget && $animateTarget.css('visibility', "");
                                  $target && $target.css('display', 'block')
                                  promise = $animate.addClass($animateTarget, options.effect).then(function () {
                                      complateShow(callback);
                                      $master.fireEvents('show');
                                      $animateTarget.show();
                                      $master.$isShowing = false;
                                      $timeout(function () {
                                          $master.$isShown = scope.$isShown = true;
                                      }, 0)

                                  });
                              }
                          }
                          else {
                              $master.$applyPlacement();
                              promise = $q.when(complateShow(callback))
                              $master.fireEvents('show');
                              $master.$isShowing = false;
                              $master.$isShown = scope.$isShown = true;
                          }

                          
                          scope.$$phase || scope.$digest();
                          if (/dropdown|popover|datepicker|colorpicker/.test(options.instanceName))
                              options.showArrow && $target.addClass('with-arrow')
                          return promise;
                      };
                      $master.leave = function (evt) {
                          var promise;
                          if (this !== $master)
                              $master.$currentElement = angular.element(this);
                          clearTimeout(timeout);
                          hoverState = 'out';
                          var exrtadelay = options.delayHide || 0;
                          if (evt && evt.type == 'mouseleave') {
                              $master.$isShowing = false;
                              !exrtadelay && (exrtadelay = 10);
                          }
                          timeout = setTimeout(function () {
                              if (hoverState === 'out') {
                                  promise = $master.hide();
                              }
                          }, exrtadelay);
                          return promise;
                      };
                      $master.hide = function (callback) {
                          
                          var promise;
                          if (!$target)
                              return false;
                          
                          if (!options.forceHide) {
                              if (!$master.$isShown)
                                  return false;
                              if ($master.$isShowing || $master.$isHidding)
                                  return false;
                          }
                          if ($master.beforeHide)
                              $master.beforeHide();
                          $master.$isHidding = true;
                          element = $master.$currentElement && $master.$currentElement || element;
                          if (options.effect) {
                              if (options.displayReflow)
                                  promise = $animate.leave($target).then(function () {
                                      complateHide(callback);
                                      if (options.effect.indexOf('collapse') > -1)
                                          $target.css('height', '');
                                      $master.fireEvents('hide')
                                      $timeout(function () {
                                          $master.$isShown = scope.$isShown = false;
                                      },0)
                                  });
                              else {
                                  $animateTarget.animationEnd(function (evt) {
                                      !$master.$isShowing && $animateTarget.hide();
                                     });
                                  $animateTarget && $animateTarget.css('visibility', "hidden");
                                  promise = $animate.removeClass($animateTarget, options.effect).then(function () {
                                     $animateTarget.hide();
                                      if ($target) {
                                          $target.hide();
                                          if (options.effect.indexOf('collapse') > -1)
                                              $animateTarget && $animateTarget.css('height', '');
                                          complateHide(callback);
                                          $master.fireEvents('hide');
                                          $timeout(function () {
                                              $master.$isShown = scope.$isShown = false;
                                          },0)
                                          
                                      }
                                  });
                              }
                          }
                          else {
                              if ($target) {
                                  $target.hide();
                                  promise = $q.when(complateHide(callback));
                                  $master.fireEvents('hide');
                                  $master.$isShown = scope.$isShown = false;
                              }
                          }
                          
                          scope.$$phase || scope.$digest();
                          return promise;

                      };
                      $master.toggle = function (elem) {
                          if (angular.isElement(elem))
                              $master.$currentElement = elem;
                          else if (this !== $master)
                              $master.$currentElement = angular.element(this);

                          $master.$isShown ? $master.leave() : $master.enter();
                      };
                      $master.focus = function () {
                          $target && $target.focus();
                      };
                      $master.clearExists = function () {
                          var exists = angular.element('.' + options.typeClass);
                          angular.forEach(exists, function (key, value) {
                              var sc = angular.element(key).scope();
                              sc && (sc.$id != scope.$id) && sc.$isShown && sc.$hide();

                          })
                      };
                      $master.$onKeyUp = function (evt) {
                          evt.which === 27 && $master.hide();
                      };
                      $master.$onFocusKeyUp = function (evt) {
                          evt.which === 27 && element.blur();
                      };
                      $master.$onFocusElementMouseDown = function (evt) {
                          if (options.isInput)
                              return true;
                          evt.preventDefault();
                          evt.stopPropagation();
                          $master.$isShown ? element.blur() : element.focus();
                      };
                      $master.$applyPlacement = function () {
                          if (options.inline)
                              return;
                          if ($container && options.container !== 'self')
                              $target.appendTo($container)
                          if (!options.preventReplace) {
                              $placement.applyPlacement($master.$toElement && $master.$toElement || $master.$currentElement && $master.$currentElement || element, $target, options)
                              $target && $target.css({ position: '' })
                          }

                      };
                      $master.fireEvents = function (status) {
                          if (options.fireEmit)
                              scope.$emit(options.prefixEvent + '.' + status, $target);
                          if (options.fireBroadcast)
                              scope.$broadcast(options.prefixEvent + '.' + status, $target);

                      };

                      $master.applyEvents = function (status) {

                          if (angular.isDefined(options.onShow))
                              scope.$on(options.prefixEvent + '.show', function () {
                                  options.$scope.$eval(options.onShow);
                                  options.$scope.$apply();
                              });
                          if (options.onHide)
                              scope.$on(options.prefixEvent + '.hide', function () {
                                  options.$scope.$eval(options.onHide);
                                  options.$scope.$apply();
                              });
                      };


                      
                      $rootScope.$on('$locationChangeStart', function (event, next, current) {
                          $master && $master.$isShown && $master.leave();
                      });
                      function onBodyClick(evt) {
                          if (evt.isDefaultPrevented())
                              return false;
                          var elm = $master.$currentElement && $master.$currentElement || element;
                          if (evt.target === elm[0])
                              return false;
                          else if (elm.has(angular.element(evt.target)))
                              return false;
                          else if ((options.multiple || options.overseeingTarget) && (evt.target == $master.$target[0] || $master.$target.has(evt.target)))
                              return false;
                          return evt.target !== elm[0] && $master.leave();
                      }
                      function outerHoverTrigger(evt) {
                          if ($master.$target[0] == evt.target || $master.$target.has(angular.element(evt.target))) {
                              if (evt.type == 'mouseenter')
                                  return hoverState = 'in';
                              else if (evt.type == 'mouseleave') {
                                  return $master.leave();
                              }
                          }
                      }
                      function build() {
                          if (options.container === 'self') {
                              $container = element;
                          } else if (options.container) {
                              var modal;
                              if (element)
                                  modal = element.closest('.modal');
                              if (modal && modal.length)
                                  $container = modal;
                              else
                                  $container = angular.isElement(options.container) ? options.container : angular.element(options.container);
                          }
                          if (!element && (!$container || $container.length < 1))
                              $container = angular.element('body');
                          $target = $master.$target = shouldCompile ? $compile(linker)(scope, function (clonedElement, scope) {
                          }) : linker;
                          ensureFixedPlacement();
                          scrollCheck();
                          $target.addClass('pop-master')
                          if (options.typeClass)
                              $target.addClass(options.typeClass)
                          if (options.displayReflow && options.effect) {
                              if ($target)
                                  $target.remove();
                          }
                          else {
                              $target.hide();
                              if ($container) {
                                  if (/input|button/.test($container[0].tagName.toLowerCase())) {
                                      $container.after($target)
                                  } else
                                      $container.append($target);
                              }
                              else
                                  element.after($target)
                          }
                          $master.applyEvents();

                          if (options.animateTarget) {
                              $animateTarget = $target.find(options.animateTarget)
                              if ($animateTarget.length < 0)
                                  $animateTarget = $target
                              else
                                  $master.$animateTarget = $animateTarget;
                          }
                          else {
                              $animateTarget = $target
                          }

                          scope.builded = true;
                          if (!$target.data('$scope'))
                              $target.data('$scope', scope);
                      }
                      function complateHide(callback) {
                          $master.$hoverShown = false;
                          if (options.keyboard && !options.isInput) {
                              angular.element(document).off('keyup', $master.$onKeyUp);
                              angular.element(document).off('keyup', $master.$onFocusKeyUp);
                          }
                          if (options.blur && options.trigger === 'focus') {
                              element && element.blur();
                          }
                          element && element.removeClass('active')
                          if (options.clearExists && (options.hasClick || options.clearStrict)) {
                              angular.element('body').off('click', onBodyClick)
                          }
                          if (options.holdHoverDelta)
                              $target.off('mouseenter mouseleave', outerHoverTrigger);
                          callback && callback.call($master);
                          $target && $target.css({ top: '', left: '' }).removeClass(lastplacement).removeClass(options.speed);
                          if (options.theme)
                              $target.removeClass(options.theme).removeClass(options.instanceName + '-' +options.theme);
                          $master.$isHidding = false;

                      }
                      function complateShow(callback) {
                          $master.$hoverShown = true;
                          if (options.keyboard && !options.isInput) {
                              if (options.trigger !== 'focus') {
                                  angular.element(document).on('keyup', $master.$onKeyUp);
                              } else {
                                  element && angular.element(document).on('keyup', $master.$onFocusKeyUp);
                              }
                          }
                          element && element.addClass('active')

                          if (options.clearExists && (options.hasClick || options.clearStrict)) {
                              angular.element('body').on('click', onBodyClick)
                          }
                          if (options.holdHoverDelta)
                              $target.on('mouseenter mouseleave', outerHoverTrigger);
                          callback && callback.call($master)

                      }
                      function ensureFixedPlacement() {
                          if (options.ensurePlacement && (!options.container || ($container && $container.css("position") === "fixed"))) {
                              if ($container && $container.css("position") === "fixed") {
                                  options.insideFixed = true;
                                  return false;
                              }
                                
                              var $checkElements = $target.add($target.parents());
                              var isFixed = false;
                              var scaleW = angular.element(window).width() / 2;
                              var scaleH = angular.element(window).height() / 2;
                              angular.forEach($checkElements, function (node) {
                                  var fx = angular.element(node);
                                  if (fx.css("position") === "fixed") {
                                      options.insideFixed = true;
                                      var val = fx.css("bottom");
                                      if ((val != 'auto' || val != 'initial') && parseInt(val) < scaleH && options.placement.indexOf("bottom-") > -1) {
                                          options.placement = options.placement.replace('bottom', 'top');
                                          options.offsetTop = -1 * options.offsetTop;
                                          return false;
                                      }
                                      val = fx.css("top");
                                      if ((val != 'auto' || val != 'initial') && parseInt(val) < scaleH && options.placement.indexOf("top-") > -1) {
                                          options.placement = options.placement.replace('top', 'bottom');
                                          options.offsetTop = -1 * options.offsetTop;
                                          return false;
                                      }
                                      val = fx.css("left");
                                      if ((val != 'auto' || val != 'initial') && parseInt(val) < scaleW && options.placement.indexOf("left-") > -1) {
                                          options.placement = options.placement.replace('left', 'right');
                                          options.offsetLeft = -1 * options.offsetLeft;
                                          return false;
                                      }
                                      val = fx.css("right");
                                      if ((val != 'auto' || val != 'initial') && parseInt(val) < scaleW && options.placement.indexOf("right-") > -1) {
                                          options.placement = options.placement.replace('right', 'left');
                                          options.offsetLeft = -1 * options.offsetLeft;
                                          return false;
                                      }
                                      return false;
                                  }
                              });
                          }


                      }
                      function scrollCheck() {
                          if (options.insideFixed && options.typeClass !== 'modal') {
                              scope.$on('staticContentScroll', function () { })
                              scope.$on('staticContentScroll', function (obj, top) {
                                  if ($master.$isShown) {
                                      $master.$applyPlacement();
                                  }
                              })
                          }
                      }
                      start();
                      return $master;
                  }
                  return MasterFactory;
              }
            ];
        })
    angular.forEach(['Modal', 'Dropdown', 'Popover'], function (directive) {
        app.directive('nqToggle' + directive, ['$helpers', '$rootScope', '$sce', '$timeout', function ($helpers, $rootScope, $sce, $timeout) {
            return {
                restrict: 'EA',
                priority: 1000,
                link: function postLink(scope, element, attr, transclusion) {

                    var itemId = attr['nqToggle' + directive], target, service, options = {}, togglerId, trigger;
                    
                    if (itemId) {
                        target = angular.element(itemId);
                    }
                    
                    if (!itemId || (target && !target.length))
                        return;
                    togglerId = $helpers.id();
                    angular.forEach(props, function (key) {
                        if (angular.isDefined(attr[key]))
                            attr.$observe(key, function (newValue, oldValue) {
                                options[key] = newValue;
                            })
                    });
                    $timeout(function () {
                        build();
                    }, 300)
                    function build() {
                        service = target.data('$nq' + directive);
                        trigger = angular.isDefined(attr.trigger) ? attr.trigger : 'click';
                        if (!angular.isObject(service))
                            return;
                        options = angular.extend({}, service.$originalOptions, options);
                        trigger = angular.isDefined(attr.trigger) ? attr.trigger : options.trigger || 'click';
                        if (trigger.indexOf('click'))
                            options.hasClick = true;
                      
                        element.on(trigger, function () {
                            if (service.$isShown) {
                                service.hide(function () {
                                    if (service.togglerId && togglerId !== service.togglerId)
                                        $timeout(function () {
                                            show();
                                        }, 10)
                                });
                            } else {
                                show();
                            }
                        })
                        
                    }
                    function show() {
                        service.$currentElement = element;
                        service.$options = angular.extend({}, options);
                        service.togglerId = togglerId;
                        extendScope();
                        service.show();
                    }
                    function extendScope() {
                        var sScope = service.$scope;
                        if (angular.isDefined(attr.qsTitle))
                            sScope.title = $sce.trustAsHtml(scope.$eval(attr.qsTitle) || attr.qsTitle);
                        if (angular.isDefined(attr.qsContent)) {
                            var newContent = scope.$eval(attr.qsContent) || attr.qsContent;
                            if (angular.isObject(newContent))
                                angular.extend(sScope, newContent);
                            else
                                sScope.content = $sce.trustAsHtml(newContent);
                        }
                            
                    }
                    scope.$on('$destroy', function () {
                        element.off(trigger)
                    });
                }
            };
        }]);
    })
}(window, window.angular);
'use strict';
angular.module('ngQuantum.popover', ['ngQuantum.popMaster'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('popover/popover.tpl.html',
          "<div class=\"popover\"><h3 class=\"popover-title\" ng-bind=\"title\" ng-show=\"title\"></h3><div class=\"popover-content\" ng-bind-html=\"content\"></div></div>"
        );

    }])
        .provider('$popover', function () {
            var defaults = this.defaults = {
                effect: 'flip-y',
                placement: 'right',
                template: 'popover/popover.tpl.html',
                contentTemplate: false,
                trigger: 'click',
                keyboard: true,
                html: false,
                title: '',
                content: '',
                clearExists: false,
                delay: 0,
                showArrow: true,
                container: 'body',
                directive: 'nqPopover',
                instanceName: 'popover',
                typeClass: 'popover',
                prefixEvent: 'popover',
                displayReflow: false,
                theme: false
            };
            this.$get = [
              '$popMaster', '$sce', '$helpers',
              function ($popMaster, $sce, $helpers) {
                  function PopoverFactory(element, config, attr) {

                      config = $helpers.parseOptions(attr, config)
                      var options = angular.extend({}, defaults, config);

                      if (!options.independent && !options.useTemplate) {
                          var target;
                          if (options.target)
                              target = angular.element(options.target);
                          else {
                              target = angular.element(element.find('.popover')[0]);
                              if (target.length < 1)
                                  target = angular.element(element.next('.popover')[0]);
                          }
                          if (target.length > 0)
                              options.targetElement = target
                      }
                      
                      var $popover = new $popMaster(element, options, attr);
                      var scope = $popover.$scope
                      options = $popover.$options = $helpers.observeOptions(attr, $popover.$options);

                      if (options.content) {
                          $popover.$scope.content = options.content;
                      }
                      if (attr) {
                          angular.forEach(['title', 'content'], function (key) {
                              var akey = 'qs' + key.capitaliseFirstLetter();
                              attr[akey] && (scope[key] = $sce.trustAsHtml(attr[akey]));
                              attr.$$observers && attr.$$observers[akey] && attr.$observe(akey, function (newValue, oldValue) {
                                  scope[key] = $sce.trustAsHtml(newValue);
                              });
                          });
                          if (attr && angular.isDefined(options.directive)) {
                              attr[options.directive] && scope.$watch(attr[options.directive], function (newValue, oldValue) {
                                  if (angular.isObject(newValue)) {
                                      angular.extend(scope, newValue);
                                  } else {
                                      scope.content = newValue;
                                  }
                              }, true);
                          }
                      }
                      scope.$on('$destroy', function () {
                          $popover.destroy();
                          $popover = null;
                      });
                      return $popover;
                  }
                  return PopoverFactory;
              }
            ];
        }).directive('nqPopover', ['$popover',
      function ($popover) {
          return {
              restrict: 'EAC',
              scope:true,
              link: function postLink(scope, element, attr) {
                  var options = {
                      $scope: scope
                  };

                  options.uniqueId = attr.qoUniqueId || attr.id || options.$scope.$id;
                  if (attr.qoTrigger && attr.qoTrigger.indexOf('hover') > -1) {
                      options.holdHoverDelta = true;
                      options.delayHide = 100;
                      options.delayShow = 10;
                  }

                  if (angular.isDefined(attr.qsTitle) || angular.isDefined(attr.qsContent) || attr.nqPopover
                      || angular.isDefined(attr.qoTemplate) || angular.isDefined(attr.qoContentTemplate))
                      options.useTemplate = true;
                  var popover = {};
                  if (angular.isDefined(attr.qoIndependent)) {
                      options.independent = true;
                      options.html = true;
                      options.useTemplate = false;
                      options.targetElement = element;
                      popover = $popover(null, options, attr);

                  }
                  else
                      popover = $popover(element, options, attr);
                  scope.$on('$destroy', function () {
                      popover = null;
                  })
                  element.data('$nqPopover', popover)
              }
          };
      }
        ]);

'use strict';
if (/chrome/.test(navigator.userAgent.toLowerCase()))
    angular.element('html').addClass('webkitscrollbar');
angular.module('ngQuantum.scrollbar', ['ngQuantum.services.helpers', 'ngQuantum.services.mouse'])
    .provider('$scrollbar', function () {
        var defaults = this.defaults = {
            barSize: 'slimest', // number in pixel or slimmest|slim|normal|thick|thickest
            barOffset: 10,
            maxWidth: false,
            placementOffset: false,
            maxHeight: false,
            useWebkit: false,
            showButtons: false,
            hideRail: false,
            padHorizontal: false,
            allDigest: false,
            step: 30,
            duration: 200,
            theme: false,
            allTags: true, // if set false tags like table, ul, ol would be ignored for scrolling,
            forceWrapper: false, //deprecated
            forceScroll: false, //deprecated
            wrapContainer: false,
            axis: 'y',
            verticalPlacement: 'right', //left|right|both
            horizontalPlacement: 'bottom', //top|bottom|both
            visible: false,
            keyboard: true
        };
        this.$get = ['$mouse','$window',
          '$compile', '$timeout',
          '$q', '$rootScope', '$helpers', function ($mouse, $window, $compile, $timeout, $q, $rootScope, $helpers) {
              var isTouch = 'createTouch' in $window.document;
              function Factory(element, config, attr) {
                  var $bar = {};
                  config = $helpers.parseOptions(attr, config);
                  var options = angular.extend({}, defaults, config);
                  var scope = options.$scope && options.$scope.$new() || $rootScope.$new(), $x = {}, $y = {}, $size = {}, $container, $barListItem;
                  $helpers.observeOptions(attr, options);
                  $bar.$scope = scope;
                  $bar.$options = options;
                  scope.scrollTop = 0, scope.scrollLeft = 0;
                  element.data('$scrollBar', $bar);
                  angular.forEach(['increase', 'decrease'], function (value) {
                      scope['$' + value] = function (axis) {
                          scope.$$postDigest(function () {
                              $bar[value](axis);
                          });
                      }
                  });
                  $bar.increase = function (axis) {
                      var a = axis == 'y' ? $y : $x;
                      var offval = options.step + (axis == 'y' ? scope.scrollTop : scope.scrollLeft),
                          tval = a.stepSize + a.thumbStep;
                      axis == 'y' ? scrollTop(offval, tval) : scrollLeft(offval, tval);
                  }
                  $bar.decrease = function (axis) {
                      var a = axis == 'y' ? $y : $x;
                      var offval = (axis == 'y' ? scope.scrollTop : scope.scrollLeft) - options.step,
                          tval = a.stepSize - a.thumbStep;
                      axis == 'y' ? scrollTop(offval, tval) : scrollLeft(offval, tval);
                  }
                  $bar.init = function () {
                      optimize();
                      buildTemplate();
                      if(!$bar.$eventsBuilded)
                          buildEvents()
                  }
                  $bar.destroy = function () {
                      element && element.off();
                      angular.element(document).off('.scrollbar');
                      angular.element(document).off('keydown', $bar.$onKeyDown);
                      scope.$destroy();
                      $bar = null;
                  }
                  $bar.$onKeyDown = function (e) {
                      if (!/(37|38|39|40)/.test(e.keyCode))
                          return;
                      if (!e.isDefaultPrevented()) {
                          e.preventDefault();
                          var code = e.keyCode, evt = e;
                          switch (code) {
                              case 37:
                              case 38:
                                  evt.deltaY = 1
                                  break
                              case 39:
                              case 40:
                                  evt.deltaY = -1
                                  break;
                          }

                          mouseWheel(evt);
                      }
                      

                  };
                  $bar.scrollStepTop = function (val) {
                      if (angular.isNumber(val)) {
                          var tval = ((val / options.step) * $y.thumbStep) + $y.stepSize;
                          scrollTop(scope.scrollTop + val, tval);
                      }

                  }
                  $bar.scrollTo = function (val, axis, diff) {
                      if (angular.isNumber(val)) {
                          !axis && (axis = 'y');
                          var a = axis != 'x' ? $y : $x;
                          var tval = (val / options.step) * a.thumbStep;
                          axis == 'y' ? scrollTop(val, tval) : scrollLeft(val, tval);
                      }
                      else {
                          var elm = [];
                          if (angular.isString(val))
                              elm = element.find(val);
                          else if (angular.isElement(val))
                              elm = val;
                          if (elm.length) {
                              if (/y|both/.test(options.axis)) {
                                  setTimeout(function () {
                                      var lval = elm[0].offsetTop - (diff || 0);
                                      var tval = (lval / options.step) * $y.thumbStep;
                                      scrollTop(lval, tval);
                                  }, 0)
                                  
                              }
                              if (/x|both/.test(options.axis)) {
                                  setTimeout(function () {
                                      var lval = elm[0].offsetLeft;
                                      var tval = (lval / options.step) * $x.thumbStep;
                                      scrollLeft(lval, tval);
                                  }, 0)
                                  
                              }
                          }
                      }
                  }
                  $bar.refresh = function (timeout) {
                      timeout = timeout || 700;
                      setTimeout(function () {
                          findSizes();
                          watchResult();
                      }, timeout)
                      
                  };
                  function optimize() {
                      if (!/y|x|both/.test(options.axis))
                          options.axis = 'y';
                      !angular.isNumber(options.barOffset) && (options.barOffset = 10)
                      !angular.isNumber(options.step) && (options.step = 30)

                      if (!/slimmest|slim|normal|thick|thickest/.test(options.barSize)) {
                          $size.barSize = parseInt(options.barSize) || 6;
                      }
                      else {
                          scope.sizeClass = 'bar-' + options.barSize
                          switch (options.barSize) {
                              case 'slimmest':
                                  $size.barSize = 4;
                                  break;
                              case 'slim':
                                  $size.barSize = 8;
                                  break;
                              case 'normal':
                                  $size.barSize = 12;
                                  break;
                              case 'thick':
                                  $size.barSize = 16;
                                  break;
                              case 'thickest':
                                  $size.barSize = 20;
                                  break;
                              default:
                                  $size.barSize = 6;
                                  break;
                          }
                      }
                      if ($size.barSize <= 12)
                          $size.buttonSize = 12;
                      else
                          $size.buttonSize = $size.barSize;
                      if (options.axis == 'both' && options.barOffset < $size.buttonSize)
                          options.barOffset = $size.buttonSize + 5;
                      if (options.useWebkit && angular.element('html').hasClass('webkitscrollbar'))
                          scope.useWebkit = true;
                  }
                  
                  function buildTemplate() {
                      if ($bar && $bar.$templateReady)
                          return;
                      $bar.$templateReady = true;
                      checkAdaptable();
                      $container.addClass('scrollable')
                      var pos = $container.css('position');
                      scope.elPosition = pos;
                      if (scope.useWebkit) {
                          if (/y|both/.test(options.axis))
                              $container.css('overflow-y', 'auto');
                          if (/x|both/.test(options.axis))
                              $container.css('overflow-x', 'auto');
                          return;
                      }
                      if (options.axis == 'y')
                          $container.css('overflow-y', 'hidden');
                      else if (options.axis == 'x')
                          $container.css('overflow-x', 'hidden');
                      else
                          $container.css('overflow', 'hidden');
                      if (!/relative|absolute|fixed/.test(pos)) {
                          $container.css('position', 'relative')
                      }
                      var barBody = $barListItem ? $barListItem : $container;
                      if (/y|both/.test(options.axis)) {
                          $y.bar = angular.element('<div class="scrollbar vertical-bar"></div>').appendTo(barBody).addClass('bar-' + options.verticalPlacement);
                          $y.track = angular.element('<div class="scrollbar-track"></div>').appendTo($y.bar);
                          $y.trackInner = angular.element('<div class="track-inner"></div>').appendTo($y.track).css('width', $size.barSize);
                          $y.thumb = angular.element('<div class="scrollbar-thumb"></div>').appendTo($y.trackInner);
                          if (options.showButtons) {
                              $y.increment = angular.element('<a class="bar-increment" ng-click="$increase(\'y\')"><span></span></a>').appendTo($y.bar).css('height', $size.buttonSize)
                              $y.decrement = angular.element('<a class="bar-decrement" ng-click="$decrease(\'y\')"><span></span></a>').prependTo($y.bar).css('height', $size.buttonSize)
                              $compile($y.bar)(scope);
                          }
                          if (angular.isNumber(options.placementOffset)) {
                              $y.bar.css(options.verticalPlacement, options.placementOffset)
                          }
                          $y.placementOffset = parseInt($y.bar.css(options.verticalPlacement)) || 0;
                          if (!isTouch) {
                              $y.trackInner.on('click', function (evt) {
                                  if (evt.target == this) {
                                      var tp = evt.offsetY
                                      if (tp > $y.stepSize)
                                          tp = tp - $y.thumb.height();
                                      var step = parseInt(tp / $y.thumbStep);
                                      var top = options.step * step, ttop = step * $y.thumbStep;
                                      scrollTop(top, ttop);
                                  }
                              })
                              $y.thumb.on('mousedown', function (e) {
                                  var last = $y.stepSize;
                                  if (e.which != 1)
                                      return true;
                                  angular.element(document).on('mousemove.scrollbar', function (evt) {
                                      var i = (evt.pageY - e.pageY) + last;
                                      var step = i / $y.thumbStep;
                                      var top = (options.step * step), ttop = (step * $y.thumbStep);
                                      scrollTop(top, ttop);
                                  })
                              })
                          }   
                      }
                      if (/x|both/.test(options.axis)) {
                          var pad = options.showButtons ? $size.buttonSize : $size.barSize
                          $x.bar = angular.element('<div class="scrollbar horizontal-bar"></div>').appendTo(barBody).addClass('bar-' + options.horizontalPlacement);
                          $x.track = angular.element('<div class="scrollbar-track"></div>').appendTo($x.bar);
                          $x.trackInner = angular.element('<div class="track-inner"></div>').appendTo($x.track).css('height', $size.barSize);
                          $x.thumb = angular.element('<div class="scrollbar-thumb"></div>').appendTo($x.trackInner);
                          if (options.showButtons) {
                              $x.increment = angular.element('<a class="bar-increment" ng-click="$increase(\'x\')"><span></span></a>').appendTo($x.bar)
                              $x.decrement = angular.element('<a class="bar-decrement" ng-click="$decrease(\'x\')"><span></span></a>').prependTo($x.bar)
                              $compile($x.bar)(scope)

                          }
                          if (options.padHorizontal)
                              if (options.horizontalPlacement == 'top') {
                                  var pt = parseInt($container.css('padding-top')) || 0;
                                  $container.css('padding-top', pad + pt + 10)
                              }
                              else {
                                  var pt = parseInt($container.css('padding-bottom')) || 0;
                                  $container.css('padding-bottom', pad + pt + 10)
                              }
                          if (angular.isNumber(options.placementOffset)) {
                              $x.bar.css(options.horizontalPlacement, options.placementOffset)
                          }
                          $x.placementOffset = parseInt($x.bar.css(options.horizontalPlacement)) || 0;
                          if (!isTouch) {
                              $x.trackInner.on('click', function (evt) {
                                  if (evt.target == this) {
                                      var tp = evt.offsetX
                                      if (tp > $x.stepSize)
                                          tp = tp - $x.thumb.width();
                                      var step = parseInt(tp / $x.thumbStep);
                                      var left = options.step * step, tleft = step * $x.thumbStep;
                                      scrollLeft(left, tleft);
                                  }
                              })
                              $x.thumb.on('mousedown', function (e) {
                                  angular.element(document).off('.scrollbar')
                                  var last = $x.stepSize;
                                  if (e.which != 1)
                                      return true;
                                  angular.element(document).on('mousemove.scrollbar', function (evt) {
                                      var i = (evt.pageX - e.pageX) + last;
                                      var step = i / $x.thumbStep;
                                      var left = (options.step * step), tleft = (step * $x.thumbStep);
                                      scrollLeft(left, tleft);
                                  })
                              })
                          }
                          
                      }
                    !isTouch &&  angular.element('body').on('mouseup', function (evt) {
                          angular.element(document).off('.scrollbar')
                      });
                      
                      
                      $container.addClass('show-bar-button')
                  }
                  function buildEvents() {
                      if (!scope.useWebkit || isTouch) {
                          if (options.allDigest)
                              scope.$watch(function (newVal, oldVal) {
                                  setTimeout(function () {
                                      watchResult();
                                  }, 0)
                              })
                          else {
                              var el = $container || element;
                              if (/y|both/.test(options.axis))
                                  scope.$watch(function () { return el[0].scrollHeight }, function (newVal, oldVal) {
                                      setTimeout(function () {
                                          watchResult();
                                      }, 0)

                                  })
                              if (/x|both/.test(options.axis))
                                  scope.$watch(function () { return el[0].scrollWidth }, function (newVal, oldVal) {
                                      setTimeout(function () {
                                          watchResult();
                                      }, 0)
                                  })
                          }

                          if (!isTouch) {
                              $mouse.onWheel(element, mouseWheel);
                              element.on('mouseenter', function (e) {
                                  if (/y|both/.test(options.axis) && !scope._scrollHeight)
                                      watchResult();
                                  if (/x|both/.test(options.axis) && !scope._scrollWidth)
                                      watchResult();
                                  if (options.keyboard) {
                                      angular.element(document).off('.scrollbarkeyboard', $bar.$onKeyDown);
                                      angular.element(document).on('keydown.scrollbarkeyboard', $bar.$onKeyDown);
                                  }

                              })
                              options.keyboard && element.on('mouseleave', function (e) {
                                  angular.element(document).off('keydown', $bar.$onKeyDown);
                              })
                          }
                          else {
                              element.on('touchstart', function (event) {
                                  var lastY = $y.stepSize || 0, lastX = $x.stepSize || 0;
                                  var sTouch = event.originalEvent.touches[0] || event.originalEvent.changedTouches[0];
                                  $y.bar && $y.bar.css('visibility', 'visible');
                                  $x.bar && $x.bar.css('visibility', 'visible');
                                  angular.element(document).on('touchmove.scrollbar', function (evt) {
                                      var touch = evt.originalEvent.touches[0] || evt.originalEvent.changedTouches[0];
                                      var newY = (sTouch.pageY - touch.pageY) + lastY;
                                      var newX = (sTouch.pageX - touch.pageX) + lastX;
                                      var retuned = false;
                                      if (/y|both/.test(options.axis)) {
                                          if (!$y.maxOffset && options.axis == 'y')
                                              retuned = true;
                                          if (scope.scrollTop == $y.maxOffset && sTouch.pageY > touch.pageY)
                                              retuned = true;
                                          if (scope.scrollTop == 0 && sTouch.pageY < touch.pageY)
                                              retuned = true;
                                      }
                                      if (/x|both/.test(options.axis)) {
                                          if (!$x.maxOffset && options.axis == 'x')
                                              retuned = true;
                                          if (scope.scrollLeft == $x.maxOffset && sTouch.pageX > touch.pageX)
                                              retuned = true;
                                          if (scope.scrollLeft == 0 && sTouch.pageX > touch.pageX)
                                              retuned = true;
                                      }
                                      if (options.axis == 'both' && !$y.maxOffset && !$x.maxOffset)
                                          retuned = true;
                                      if (retuned)
                                          return true;
                                      event.preventDefault();
                                      evt.preventDefault();
                                      if (/y|both/.test(options.axis)) {
                                          var step = newY / $y.thumbStep;
                                          var top = (options.step * step), ttop = (step * $y.thumbStep);
                                          scrollTop(top, ttop);
                                      }
                                      if (/x|both/.test(options.axis)) {
                                          var step = newX / $x.thumbStep;
                                          var left = (options.step * step), tleft = (step * $x.thumbStep);
                                          scrollLeft(left, tleft);
                                      }

                                  })
                              })
                              angular.element(document).on('touchend.scrollbar touchcancel.scrollbar', function (evt) {
                                  $y.bar && $y.bar.css('visibility', 'hidden');
                                  $x.bar && $x.bar.css('visibility', 'hidden');
                                  angular.element(document).off('touchmove')
                              })
                          }


                      }
                      $bar.$eventsBuilded = true;
                  }
                  
                  function watchResult() {
                      if ($container && $container.height() < 0 || !$container && element && element.height() < 1)
                          return;
                      $y.bar && $y.bar.hide();
                      $x.bar && $x.bar.hide();
                      var tag = element[0].tagName, width = 0, height = 0;
                      var pad = options.showButtons ? $size.buttonSize : $size.barSize;
                      if (/td|th|table/.test(tag.toLowerCase())) {
                          if ($container) {
                              height = $container[0].scrollHeight - pad;
                              width = $container[0].scrollWidth;
                          }
                          else {
                              height = element[0].clientHeight - pad;
                              width = element[0].clientWidth;
                          }
                      }
                      else {
                          height = element[0].scrollHeight - pad;
                          width = element[0].scrollWidth;
                      }
                      if (/y|both/.test(options.axis)) {
                          if (height > 0 && scope.maxHeight < height && $container && $container.outerHeight() >= scope.maxHeight && ($container[0].scrollHeight > $container[0].clientHeight)) {
                                  scope._scrollHeight = height, applyY(height);
                              $y.bar && $y.bar.css('visibilty', '').show();
                              $y.bar.visible = true;
                          } else {
                              $container.scrollTop(0)
                              $y.bar && $y.bar.css('visibilty', 'hidden');
                              $y.bar.visible = false;
                          }
                          if (scope.scrollTop > 0 && $container.height() < height) {
                              $container.scrollTop(scope.scrollTop);
                          }
                      }
                      if (/x|both/.test(options.axis)) {
                          if (width > 0 && scope.maxWidth < width && $container.outerWidth() >= scope.maxWidth && $container && ($container[0].scrollWidth > $container[0].clientWidth)) {
                                  scope._scrollWidth = width, applyX(width);
                              $x.bar && $x.bar.css('visibilty', '').show();
                              $x.bar.visible = true;
                          } else {
                              $container.scrollLeft(0)
                              $x.bar && $x.bar.css('visibilty', 'hidden')
                              $x.bar.visible = false;
                          };


                          if (scope.scrollLeft > 0 && $container.width() < width) {
                              $container.scrollLeft(scope.scrollLeft);
                          }
                      }
                  }
                  function mouseWheel(event) {
                      if (options.axis == 'y') {
                          if (!$y.bar.visible)
                              return true;
                          if (!scope._scrollHeight)
                              watchResult();
                          if (!$y.maxOffset)
                              return true;
                          if (scope.scrollTop >= $y.maxOffset && event.deltaY < 0)
                              return true;
                          
                          if (scope.scrollTop == 0 && event.deltaY > 0)
                              return true;
                          event.preventDefault();
                          wheelTop(event)
                      }
                      else if (options.axis == 'x') {
                          if (!$x.bar.visible)
                              return true;
                          if (!$x.maxOffset)
                              return true;
                          if (scope.scrollLeft >= $x.maxOffset && event.deltaY < 0)
                              return true;
                          if (scope.scrollLeft == 0 && event.deltaY > 0)
                              return true;
                          event.preventDefault();
                          wheelLeft(event)
                      }
                      else if (options.axis == 'both') {
                          if ($y.maxOffset && scope.scrollTop < $y.maxOffset && event.deltaY < 0) {
                              event.preventDefault();
                              wheelTop(event)
                          }
                          else if ($x.maxOffset && scope.scrollLeft < $x.maxOffset && event.deltaY < 0) {
                              event.preventDefault();
                              wheelLeft(event)
                          }
                          else if (scope.scrollLeft > 0 && event.deltaY > 0) {
                              event.preventDefault();
                              wheelLeft(event)
                          }
                          else if (scope.scrollTop > 0 && event.deltaY > 0) {
                              event.preventDefault();
                              wheelTop(event)
                          }
                          else
                              return true;
                      }
                  }
                  function wheelTop(event) {
                      var top = scope.scrollTop;
                      top = event.deltaY > 0 ? top - options.step : top + options.step;
                      var mtop = event.deltaY > 0 ? $y.stepSize - $y.thumbStep : $y.stepSize + $y.thumbStep;
                      
                      scrollTop(top, mtop)
                  }
                  function scrollTop(btop, ttop) {
                      btop = validateOffset(btop, $y.maxOffset)
                      ttop = validateOffset(ttop, $y.maxThumbOffset);
                      $y.stepSize = ttop;
                      $container.scrollTop(btop);
                      $y.thumb && $y.thumb.css('top', ttop + 'px');
                      $y.bar && $y.bar.css('top', btop + options.barOffset + 'px')
                      if ($x.bar) {
                          $x.bar.css(options.horizontalPlacement, -(btop - $x.placementOffset))
                      }
                      scope.scrollTop = btop;
                  }
                  function wheelLeft(event) {
                      var left = scope.scrollLeft;
                      left = event.deltaY > 0 ? left - options.step : left + options.step;
                      var mleft = event.deltaY > 0 ? $x.stepSize - $x.thumbStep : $x.stepSize + $x.thumbStep;

                      scrollLeft(left, mleft);
                  }
                  function scrollLeft(left, mleft) {
                      left = validateOffset(left, $x.maxOffset)
                      mleft = validateOffset(mleft, $x.maxThumbOffset)
                      $x.stepSize = mleft;
                      $container.scrollLeft(left);
                      $x.thumb && $x.thumb.css('left', mleft + 'px');
                      $x.bar && $x.bar.css('left', left + options.barOffset + 'px')
                      if ($y.bar) {
                          $y.bar.css(options.verticalPlacement, -(left - $y.placementOffset))
                      }
                      scope.scrollLeft = left;

                  }
                  function validateOffset(val, max) {
                      var result = val;
                      if (val > max)
                          result = max + 0.1;
                      if (val < 0)
                          result = 0
                      return result;
                  }
                  function barSizes(axis, newsize, elsize) {
                      var $a = axis, oldStepRange = ($a.stepSize && $a.thumbStep) && ($a.stepSize / $a.thumbStep);
                      var s = elsize,
                      bs = s - (2 * options.barOffset),
                       ts = s * s / newsize;
                      $a.barSize = bs;
                      $a.trackSize = bs;
                      if (options.showButtons) {
                          $a.trackSize = bs - ($size.buttonSize * 2) - 6;
                      }
                      $a.thumbSize = ts;
                      $a.maxOffset = newsize - s;
                      var mts = $a.trackSize - ts;
                      $a.maxThumbOffset = mts;
                      $a.thumbStep = (($a.trackSize - ts) / ($a.maxOffset / options.step))
                      $a.stepSize = oldStepRange ? (oldStepRange * $a.thumbStep) : 0;
                      $a.stepSize > $a.maxThumbOffset && ($a.stepSize = $a.maxThumbOffset);
                      return $a;
                  }
                  function checkAdaptable() {
                      var tag = element[0].tagName;
                      findSizes();
                      if (/ul|ol/.test(tag.toLowerCase()) && !scope.useWebkit) {
                          $barListItem = angular.element('<li class="scrollbar-list-item"></li>').appendTo(element);
                          $container = element;
                      }
                      else if (tag.toLowerCase() == 'table') {
                          $container = angular.element('<div class="scrollbar-container"></div>').insertBefore(element).append(element);
                          applySizes();
                      }
                      else if (/td|th/.test(tag.toLowerCase())) {
                          $container = angular.element('<div class="scrollbar-container"></div>').appendTo(element);
                          applySizes();
                      }
                      else {
                          $container = element;
                          if (options.maxWidth || options.maxHeight)
                              applySizes();
                      }
                      scope.sizeClass && $container.addClass(scope.sizeClass);
                      options.theme && $container.addClass('bar-' + options.theme);
                      options.visible && $container.addClass('bar-visible');
                      options.hideRail && $container.addClass('hide-rail');
                      !scope.useWebkit && $container.addClass('no-webkit');
                      !options.showButtons && $container.addClass('hide-bar-button');
                  }
                  function findSizes() {
                      var exchild = false;
                      $size.width = options.maxWidth ? options.maxWidth : element.css('max-width') || element.css('width');
                      $size.height = options.maxHeight ? options.maxHeight : element.css('max-height') || element.css('height');
                      scope.maxWidth = angular.isNumber($size.width) ? $size.width : angular.isString($size.width)
                          ? $size.width.indexOf('%') !== -1 ? (element.parent().innerWidth() * ((parseFloat($size.width) / 100) || 0)) : parseFloat($size.width) || 0 : 0;
                      scope.maxHeight = angular.isNumber($size.height) ? $size.height : angular.isString($size.height)
                          ? $size.height.indexOf('%') !== -1 ?
                          function () {
                              exchild = true;
                              return element.parent().innerHeight() * ((parseFloat($size.height) / 100) || 0)
                          }() : parseFloat($size.height) || 0 : 0;
                  }
                  function applySizes(elm) {
                      var cont = elm ? elm : $container;
                      if (/y|both/.test(options.axis)) {
                          cont.css('max-height', $size.height)
                      }
                      if (/x|both/.test(options.axis))
                          cont.css('max-width', $size.width)
                  }
                  function applyY(newval) {
                      newval = newval || $container[0].scrollHeight;
                      
                      var maxtop = $container[0].scrollHeight - $container.outerHeight();
                      if (maxtop < scope.scrollTop)
                          scope.scrollTop = maxtop;
                      if (newval && /y|both/.test(options.axis)) {
                          var h = $container.outerHeight(true);
                          $y = barSizes($y, newval, h);
                          if (!$bar || !$bar.$templateReady)
                              buildTemplate();
                          $y.bar.css({
                              top: (scope.scrollTop || 0) + options.barOffset + 'px',
                              bottom: options.barOffset + 'px',
                              height: $y.barSize + 'px'
                          })
                          $y.thumb.css({
                              height: $y.thumbSize + 'px',
                              top: $y.stepSize + 'px'
                          })
                          $y.track.css({
                              height: $y.trackSize + 6 + 'px'
                          })
                      }
                  }
                  function applyX(newval) {
                      newval = newval || $container[0].scrollWidth;
                      var maxleft = $container[0].scrollWidth - $container.outerWidth();
                      if (maxleft < scope.scrollLeft)
                          scope.scrollTop = maxleft;
                      if (newval && /x|both/.test(options.axis)) {
                          var w = $container.outerWidth(true)
                          $x = barSizes($x, newval, w);
                          
                          if (!$bar.$templateReady)
                              buildTemplate();
                          $x.bar.css({
                              left: (scope.scrollLeft || 0) + options.barOffset + 'px',
                              right: options.barOffset + 'px',
                              width: $x.barSize + 'px'
                          })
                          $x.thumb.css({
                              width: $x.thumbSize + 'px',
                              left: $x.stepSize + 'px'
                          })
                          $x.track.css({
                              width: $x.trackSize + 6 + 'px'
                          })
                      }
                  }
                  options.$scope && options.$scope.$on('$destroy', function () {
                      $bar.destroy();

                  })
                  var windowResize = function () {
                      $timeout(function () {
                          $bar.refresh(200)
                      }, 100)
                  };
                  
                  window.addResizeEvent(windowResize)
                  angular.element(document).ready(function () {
                      setTimeout(function () {
                          windowResize();
                      }, 200)
                      
                  })
                  $bar.init();
                  return $bar;
              };
              return Factory;
          }];
    })
    .directive('nqScroll',
      ['$scrollbar', '$timeout', function ($scrollbar, $timeout) {
          return {
              restrict: 'AC',
              isolate: false,
              link: function postLink(scope, element, attr) {
                  setTimeout(function () {
                      var bar = $scrollbar(element, { $scope: scope }, attr)
                      if (attr.barModel)
                          scope[attr.barModel] = bar;
                  }, 10)
              }
          };
      }])

+function (window, angular, undefined) {
'use strict';
var selectApp = angular.module('ngQuantum.select', [
      'ngQuantum.popMaster',
      'ngQuantum.scrollbar'
    ])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('select/select.tpl.html',
          '<div tabindex="-1" class="listbox-panel ng-cloak" role="listbox"><div class="scrollable" role=\"listbox\"><ul tabindex=\"-1\" class=\"listbox\"><li role=\"presentation\" tabindex=\"-1\" ng-repeat=\"match in $matches track by $index\"><span class=\"select-option option-label\"  role=\"option\" tabindex=\"-1\" ng-click=\"$select(match)\" ng-bind=\"match.label\"></span> </li></ul></div></div>'
        );
        $templateCache.put('select/selectgroup.tpl.html',
          '<div tabindex="-1" role="listbox" class="listbox-panel ng-cloak"><div tabindex="-1" class="scrollable" role="listbox"> <ul tabindex="-1" class="listbox"> <li tabindex="-1" role="presentation" ng-repeat="match in $groupMatches">  <span class="select-option" ng-if="!match.items" role="option" tabindex="-1" ng-disabled="match.disabled" ng-click="$select(match)"> <span class="option-label" ng-bind="match.label"></span> </span> <div tabindex="-1" class="option-group" ng-if="match.items" ng-disabled="match.disabled"> <span class="group-label" ng-bind="match.label"></span> <ul tabindex="-1">  <li tabindex="-1" role="presentation" data-ng-repeat="item in match.items track by $index"> <span class="select-option" role="option" tabindex="-1" ng-disabled="item.disabled" ng-click="$select(item)"><span class="option-label" ng-bind="item.label"></span></span></li></ul></div></li></ul></div></div>'
        );
    }])
    .provider('$select', function () {
        var defaults = this.defaults = {
            effect: 'sing',
            typeClass: 'select',
            prefixClass: 'select',
            buttonClass: 'btn-default',
            navClass: 'nav-mixed',
            prefixEvent: 'select',
            placement: 'bottom-left',
            template: 'select/select.tpl.html',
            groupTemplate: 'select/selectgroup.tpl.html',
            trigger: 'click',
            fireEmit: false,
            lazyAjax:true,
            container: 'body',
            displayReflow: false,
            disableClear: false,
            keyboard: true,
            multiple: false,
            filterable: true,
            highlight: true,
            showTick: true,
            urlPrefix: false,
            isQuerystring: false,
            cacheResult: true,
            caseSensitive: true,
            seperator: ', ',
            html: true,
            clearIcon: '<span class="clear-icon fu-cross"></span>',
            spinner: '<span class="spin-icon fu-spinner-fan spin"></span>',
            noMatch: 'No result found...',
            placeholder: 'Please select...',
            filterText: 'search...',
            charText: 'Please enter {{$remainingChar}} or more characters',
            searchingText: 'Searching...',
            maxLength: 3,
            maxTextLength: 30,
            minTextLength: 3,
            minChar: 3,
            forceHide:false,
            selectedRemovable: true
        };
        this.$get = [
            '$filter',
          '$window',
          '$http',
          '$compile',
          '$rootScope',
          '$popMaster',
          '$parseOptions',
          '$timeout',
          '$q',
          '$scrollbar',
          '$lazyRequest',
          '$helpers',
          function ($filter, $window, $http, $compile, $rootScope, $popMaster, $parseOptions, $timeout, $q, $scrollbar, $lazyRequest, $helpers) {
              var bodyEl = angular.element($window.document.body);
              var isTouch = 'createTouch' in $window.document;
              function SelectFactory(element, controller, config, attr, targetEl) {
                  config = $helpers.parseOptions(attr, config);
                  !config.template && config.grouped && (config.template = defaults.groupTemplate)
                  var $select = {}, inputItem, scrollbar;
                  var searchInput = angular.element(['<input ng-hide="$hideFilter" ng-model="filterModel.label" type="text" autocomplete="off" autocorrect="off" autocapitalize="off" spellcheck="false" placeholder="{{$placeholder}}" class="select-input form-control" role="combobox" aria-expanded="true"',
                                    , ' aria-autocomplete="list" style="max-width:100%;" />'].join(""))

                  var options = angular.extend({}, defaults, config);
                  var isTagsInput = controller.isTagsInput = (options.directive == 'nqTagsInput');
                  var clearIcon = options.clearIcon;
                  var noMatch, charLabel, searchLabel;
                  if (options.filterable) {
                      if (angular.isString(options.noMatch) && options.noMatch.length > 2 && options.noMatch.substr(0, 1) == '#')
                          noMatch = angular.element(document).find(options.noMatch)
                      else
                          noMatch = angular.element('<span>' + options.noMatch + '</span>');
                      !noMatch.length && (noMatch = null)
                      if (noMatch)
                          noMatch.addClass('no-match').attr('ng-show', '$noResultFound')
                  }
                  if (options.inline) {
                      options.show = true;
                      options.trigger = false;
                      options.showArrow = false;
                      options.container = false;
                      element.addClass('listbox-inline');
                      options.effect = false;
                      options.autoHide = false;
                  }
                  $select = new $popMaster(element, options);
                  var scope = $select.$scope;
                  options = $select.$options = $helpers.observeOptions(attr, $select.$options);
                  $select.optionData = [];
                  scope.$matches = [];
                  scope.urlParams = [];
                  $select.searchInput = searchInput;
                  scope.$selectedIndex = options.multiple ? [] : -1;
                  scope.$isMultiple = options.multiple;
                  scope.$remainingChar = options.minChar;
                  scope.$placeholder = options.displayType == 'input' ? options.placeholder : options.filterText;
                  scope.$select = function (index, evt) {
                      scope.$$postDigest(function () {
                          $select.select(index);
                      });
                  };
                  var init = $select.init, $target;
                  $select.init = function () {
                      init();
                      options.displayType !== 'input' && element.addClass(options.buttonClass)
                      $target = $select.$target;
                      if (options.filterable && $target) {
                          $compile(searchInput)(scope)

                          if (options.displayType == 'input') {
                              options.navClass && element.addClass(options.navClass);
                              options.inputSize && element.addClass(options.inputSize)
                              inputItem = angular.element('<li></li>').append(searchInput.removeClass('form-control').removeClass('input-xs'))
                              element.append(inputItem)
                              !options.multiple && element.addClass('single-option')
                          }
                          else {
                              options.buttonClass && element.addClass(options.buttonClass)
                              $target.prepend(searchInput);
                              searchInput.on('click', function (e) {
                                  e.preventDefault();
                                  searchInput.focus();
                              })
                          }
                      }
                      if (noMatch) {
                          $compile(noMatch)(scope)
                          $target.append(noMatch)
                      }

                      options.showTick && $target.addClass('show-tick')

                      if (options.url && !options.remoteSearch) {
                          if (options.lazyAjax) {
                              $lazyRequest(function () {
                                  return $select.loadRemote();
                              },0)
                          }
                          else
                              $select.loadRemote();
                      }

                      if (options.remoteSearch) {
                          charLabel = angular.element('<span ng-show="$remainingChar > 0"></span>').append(options.charText)
                          searchLabel = angular.element('<span class="search-label" ng-show="$dataLoading"></span>').append(options.searchingText)
                          options.spinner && searchLabel.append(options.spinner)
                          $compile(charLabel)(scope)
                          $compile(searchLabel)(scope)
                          $target.append(charLabel);
                          $target.append(searchLabel);
                      }
                      $select.complated = true;
                      if (!$select.renderComplated)
                          $select.render();
                      !(options.displayType == 'input') && element.addClass('select-toggle')

                      searchInput && searchInput.attr('maxlength', options.maxTextLength);
                      if ($target) {
                          var barelement = $target.find('.scrollable');
                          var barOptions = {
                              keyword: false,
                              barSize: 'slimmest',
                              placementOffset: -2,
                              $scope: scope
                          }
                          scrollbar = $scrollbar(barelement, barOptions);
                      }
                  };
                  $select.update = function (matches) {
                      var selected = $filter('filter')($select.optionData, { selected: true })
                      $select.optionData = matches;
                      angular.forEach(selected, function (item) {
                          $select.addOption(item)
                      })
                      $select.updateMatches()
                  };
                  $select.addOption = function (item) {
                      var exists = $filter('filter')($select.optionData, function (val, i) {
                          if (!options.caseSensitive && (angular.isString(val.label)))
                              return val.label.toLowerCase() == (angular.isString(item.label) ? item.label.toLowerCase() : item.label)
                          return val.value == item.value;
                      });
                      if (!exists.length) {
                          $select.optionData.push(item);
                          scope.$matches = $select.optionData;
                          return $select.optionData[$select.optionData.length - 1];
                      }
                      return exists[0]


                  };
                  $select.changeOption = function (key, value) {
                      options[key] = value;
                  };
                  $select.updateMatches = function (matches, isfilter) {
                      scope.$matches = matches || $select.optionData;
                      if (options.grouped)
                          scope.$groupMatches = $filter('groupOption')(scope.$matches);
                      scope.$noResultFound = !scope.$matches.length;
                      if (isTagsInput, isfilter) {
                          scope.$noResultFound = !(($filter('filter')(scope.$matches, function (val) { return val.filtered != true })).length)

                          scope.$noResultFound ? $select.hide() : $select.show();
                      }
                  };
                  $select.select = function (item) {
                      if (options.multiple) {
                          if (!item.selected && options.maxLength && (controller.$modelValue && controller.$modelValue.length == options.maxLength))
                              return
                          else {
                              scope.$apply(function () {
                                  item.selected = isTagsInput ? true : item.selected ? false : true;
                                  item.filtered = isTagsInput && item.selected;
                              })
                              var selected = []
                              $filter('filter')($select.optionData, function (opt) {
                                  opt.selected && selected.push(opt.value);
                              })
                              $timeout(function () {
                                  controller.$setViewValue(selected);
                              }, 0)
                          }
                      } else {
                          if (!scope.fistChanged) {
                              $filter('filter')($select.optionData, function (itm, key) {
                                  if (itm.selected) {;
                                      scope.$lastSelected = itm
                                      scope.fistChanged = true;
                                  }
                              })
                          }

                          scope.$apply(function () {
                              item.selected = true;
                          })
                          scope.$lastSelected && !(scope.$lastSelected === item) && (scope.$lastSelected.selected = false);
                          scope.$lastSelected = item;
                          $timeout(function () {
                              controller.$setViewValue(item.value);
                          }, 0)
                      }
                      $timeout(function () {
                          $select.render();
                      }, 0)

                      if (!options.multiple) {
                          if (options.trigger === 'focus')
                              element[0].blur();
                          else if ($select.$isShown || $select.$isHidding)
                              $select.hide();
                      }
                      if (isTagsInput)
                          $select.hide();
                      scope.$emit('$select.select', item);
                      searchInput.val('')
                  };
                  $select.$getIndex = function (value) {
                      var l = $select.optionData.length, i = l;
                      if (!l)
                          return;
                      for (i = l; i--;) {
                          if ($select.optionData[i].value === value)
                              break;
                      }
                      if (i < 0)
                          return;
                      return i;
                  };
                  $select.$onMouseDown = function (evt) {
                      evt.preventDefault();
                      evt.stopPropagation();
                      if (isTouch) {
                          var targetEl = angular.element(evt.target);
                          targetEl.triggerHandler('click');
                      }
                  };
                  $select.$onKeyDown = function (e) {
                      if (!/(38|40|13)/.test(e.keyCode))
                          return true;
                      e.preventDefault();
                      e.stopPropagation();
                      
                      var $items = $target.find('.select-option:visible');
                    
                      if (!$items || !$items.length) return;
                      $target.focus();
                      var index = scope.$lastIndex > -1 ? scope.$lastIndex : -1;
                      if (index == -1) {
                          var elSelected = angular.element($target.find('.selected')[0]),
                              sIndex = elSelected.length && elSelected.scope().$index;
                          index = angular.isDefined(sIndex) ? sIndex : elSelected.hasClass('select-option') ? elSelected.parent().index() : elSelected.closest('.select-option').index();
                      }
                      index >= $items.length && (index = 0)
                      if (e.keyCode == 38 && index > 0) index--                  // up
                      if (e.keyCode == 40 && index < $items.length - 1) index++  // down
                      if (!~index) index = 0

                      if (e.keyCode === 13) {
                          var match = $filter('filter')(scope.$matches, function (itm) { return itm.filtered != true })[index]
                          if (match)
                              return $select.select(match);
                      }
                      $items.eq(index).focus();
                      scope.$lastIndex = index;

                  };

                  var _show = $select.show;
                  $select.show = function () {
                      var promise = _show();
                      if (options.multiple) {
                          $select.$target.addClass('select-multiple');
                      }
                      if (options.keyboard && $select.$target) {
                          angular.element(document).off('keydown', $select.$onKeyDown);
                          angular.element(document).on('keydown', $select.$onKeyDown);
                      }

                      $select.$target.css('min-width', element.outerWidth(true));
                      promise && promise.then(function () {
                          if (options.filterable) {
                              if (options.directive != 'nqTagsInput')
                                  scope.filterModel = { label: '' };
                              setTimeout(function () {
                                  searchInput.focus();
                              }, 0);
                          }
                          if (scrollbar) {
                              scrollbar.scrollTo('.selected', null, 60);
                          }
                          $select.$target.on(isTouch ? 'touchstart' : 'mousedown', $select.$onMouseDown);
                      })
                  };
                  var _hide = $select.hide;
                  $select.hide = function () {
                      $select.$target.off(isTouch ? 'touchstart' : 'mousedown', $select.$onMouseDown);
                      if (options.keyboard && $select.$target)
                          angular.element(document).off('keydown', $select.$onKeyDown);
                     
                      if (options.directive != 'nqTagsInput')
                          searchInput.val('');
                      scope.$lastIndex = -1;
                      if (options.inline)
                          return $q.when('');


                      var promise = _hide() || $q.when('');
                      promise.then(function () {
                          if (options.directive != 'nqTagsInput') {
                              scope.filterModel = { label: '' };
                              setTimeout(function () {
                                  searchInput.blur();
                              }, 0);
                          }
                      })
                  };

                  $select.render = function () {
                      if (controller.$modelValue && options.modelIsLabel) {
                          if ($select.complated) {
                              if (angular.isArray(controller.$modelValue)) {
                                  angular.forEach(controller.$modelValue, function (val) {
                                      var item = { label: val, value: val, selected: true, filtered: isTagsInput }
                                      item = $select.addOption(item)
                                  })
                              }
                              else if (options.modelIsLabel) {
                                  $select.addOption({ label: controller.$modelValue, value: controller.$modelValue, selected: true, filtered: isTagsInput })

                              }
                              renderController();
                          }
                      }
                      else if (controller.$modelValue && options.remoteSearch && !$select.optionData.length) {
                          if (options.lazyAjax) {
                              $lazyRequest(function () {
                                 return $select.loadRemote(null, controller.$modelValue);
                              }, 0)
                          }
                          else
                              $select.loadRemote(null, controller.$modelValue);
                      }
                      else if ($select.complated)
                          renderController();
                      validateModel();

                  };
                  $select.loadRemote = function (term, data) {
                      scope.$dataLoading = true;
                      var post = (data && data.length) ? true : false;
                      var url = buildUrl(term, post)
                      var ajax = {
                          url: url
                      }
                      ajax.method = post ? 'POST' : 'GET';
                      ajax.cache = options.cacheResult;
                      post && (ajax.data = { ModelValue: data });
                      return $http(ajax)
                           .success(function (res) {
                               if (options.resultKey)
                                   scope[options.resultKey] = res.data ? res.data : res;
                               else
                                   scope.selectOptions = res.data ? res.data : res;
                               scope.$dataLoading = false;
                               scope.$noResultFound = res.data ? !res.data.length : !res.length
                               !$select.fistLoad && setTimeout(function () {
                                   renderController();
                               }, 0)
                               $select.fistLoad = true;
                               term && (scope.lastTerm = term);
                           })
                           .error(function (res) {
                               scope.$dataLoading = false;
                               scope.$noResultFound = true;
                           })
                  }
                  if (options.filterable)
                      scope.$watch('filterModel.label', function (newValue, oldValue) {
                          if (options.remoteSearch)
                              remoteFiler(newValue, oldValue)
                          else
                              localFiler(newValue, oldValue);

                          if (searchInput && newValue) {
                              searchInput.css('min-width', newValue.length * 0.7 + 'em')
                          }
                          var scrollVal = newValue ? 0 : '.selected';
                          if (scrollbar && newValue) {
                              scrollbar.scrollTo(scrollVal, 'y', 10);
                          }

                      });
                  if (attr) {
                      angular.forEach(['urlParams'], function (key) {
                          attr[key] && attr.$observe(key, function (newValue, oldValue) {
                              scope[key] = newValue;
                          });
                      });
                  }
                  if (angular.isDefined(attr.ngOptions)) {
                      var parsedOptions = $parseOptions(attr.ngOptions);
                      var watchedOptions = parsedOptions.$match[7].replace(/\|.+/, '').trim();
                      scope.$watch(watchedOptions, function (newValue, oldValue) {
                          parsedOptions.valuesFn(scope, controller).then(function (values) {
                              if (values && angular.isArray(values)) {
                                  $select.update(values);
                                  $select.render();
                              }
                          });
                      });
                  }
                  else if (targetEl.is('select')) {
                      $q.when(targetEl).then(function (el) {
                          var parsedOptions = $parseOptions(null, el);
                          if (parsedOptions.$values && angular.isArray(parsedOptions.$values)) {
                              $select.update(parsedOptions.$values);
                              controller.$render();
                          }
                      });
                  }
                  else {
                      controller.$render();
                  }
                  if (angular.isDefined(attr.ngChange)) {
                      scope.$parent.$watch(function () { return controller.$modelValue }, function (newValue, oldValue) {
                          scope.$parent.$eval(attr.ngChange);
                      });
                  }
                  function renderController() {
                      $select.renderComplated = true;
                      var selected, index;
                      clearSelected();
                      if (options.displayType == 'input') {
                          if (controller.$modelValue)
                              renderSelected();
                      }
                      else {
                          if (options.multiple && angular.isArray(controller.$modelValue)) {
                              selected = controller.$modelValue.map(function (value) {
                                  index = $select.$getIndex(value);
                                  if (angular.isDefined(index)) {
                                      $select.optionData[index].selected = true
                                      return $select.optionData[index].label
                                  }
                                  return false
                              }).filter(angular.isDefined)
                              selected = selected.join(options.seperator)
                          } else {
                              index = $select.$getIndex(controller.$viewValue);
                              if (angular.isDefined(index)) {
                                  $select.optionData[index].selected = true
                                  selected = $select.optionData[index].label
                              }
                              else
                                  selected = false;
                          }
                          if (selected) {
                              element.html(selected)
                              if (!options.disableClear && !options.multiple) {
                                  var clrIcon = angular.element(clearIcon)
                                  clrIcon.one('click', function (evt) {
                                          evt.preventDefault();
                                          evt.stopPropagation();
                                          $timeout(function () {
                                              scope.$lastSelected && (scope.$lastSelected.selected = false);
                                              controller.$setViewValue(null);
                                              controller.$render()
                                          }, 0)

                                      });
                                  element.append(clrIcon)
                              }
                          }
                          else
                              element.html(options.placeholder)
                      }
                  }
                  function renderSelected() {
                      var current = element.find('li')
                      angular.forEach(current, function (elm, key) {
                          if (key < current.length - 1)
                              elm.remove()
                      })
                      if (angular.isArray(controller.$modelValue)) {
                          angular.forEach(controller.$modelValue, function (value, key) {
                              var index = $select.$getIndex(value)
                              if (index > -1) {
                                  $select.optionData[index].selected = true
                                  inputItem.before(renderItem($select.optionData[index], key));
                              }
                          })
                      }
                      else {
                          var index = $select.$getIndex(controller.$modelValue)
                          if (index > -1) {
                              $select.optionData[index].selected = true
                              inputItem.before(renderItem($select.optionData[index], controller.$modelValue));
                          }
                      }
                      $select.$isShown &&
                      $select.$applyPlacement();
                  }
                  function renderItem(item, key) {
                      var li = angular.element('<li class="active"></li>')
                      li.on('click', function (e) { e.preventDefault(), e.stopPropagation() })
                      var closer = angular.element(options.clearIcon)
                                   .one('click', function (e) {
                                       e.preventDefault();
                                       e.stopPropagation();
                                       if (angular.isArray(controller.$modelValue)) {
                                           controller.$modelValue = controller.$modelValue.splice(key, 1);
                                       }
                                       else
                                           controller.$modelValue = null
                                       li.off()
                                       li.remove()
                                       scope.$apply(function () {
                                           item.selected = false;
                                           item.filtered = false;
                                       })
                                   });
                      return li.append(angular.element('<a></a>').append(item.label).append(closer))
                  }
                  function highlightText(value) {
                      setTimeout(function () {
                          if (options.highlight && $target) {
                              var items = $target.find('.option-label')
                              if (items.length) {
                                  angular.forEach(items, function (val) {
                                      var el = angular.element(val);
                                      if (value)
                                          el.html(el.text().replace(new RegExp('(' + value + ')', 'gi'), '<span class="highlight">$1</span>'));
                                      else
                                          el.html(el.text());
                                  })
                              }
                          }
                      }, 100)
                      
                  }
                  function localFiler(newValue, oldValue) {
                      if (!options.customFilter) {
                          if (newValue) {
                              $select.updateMatches($filter('filter')($select.optionData, scope.filterModel), isTagsInput);
                          }
                          else if (!newValue && oldValue)
                              $select.updateMatches(undefined, isTagsInput)
                      }
                      else {
                          if (!newValue && !oldValue)
                              return;
                          var i = 0
                          $filter('filter')($select.optionData, function (obj) {
                              if (isTagsInput && obj.selected)
                                  obj.filtered = true
                              else {
                                  if (obj.label.search(new RegExp(newValue, "i")) < 0)
                                      obj.filtered = true
                                  else {
                                      obj.filtered = false;
                                      i++;
                                  }
                              }
                          })
                          scope.$noResultFound = !i;
                      }
                      highlightText(newValue)
                  }
                  function remoteFiler(newValue, oldValue) {
                      if (newValue) {
                          scope.$remainingChar = options.minChar - newValue.length;
                          scope.$noResultFound = false;
                          if (scope.$remainingChar == 0 && scope.lastTerm != newValue)
                              $select.loadRemote(newValue);
                          else
                              localFiler(newValue, oldValue);
                      }
                  }
                  function buildUrl(term, isPost) {
                      var url = options.urlPrefix || '';
                      url += isPost ? options.postUrl ? options.postUrl : options.url : options.url;
                      if (term) {
                          if (scope.urlParams.length) {
                              angular.forEach(scope.urlParams, function (value, index) {
                                  var param = getParam(value, index)
                                  if (options.isQuerystring) {
                                      url += index == 0 ? '?' : '&';
                                      url += param.param + '=' + param.value;
                                  }
                                  else {
                                      url += '/' + param.value;
                                  }
                              })
                          }
                          if (options.isQuerystring) {
                              url += scope.urlParams.length ? '&' : '?';
                              url += 'term=' + term;
                          }
                          else {
                              url += '/' + term;
                          }
                      }
                      return url;
                  }
                  function getParam(value, index) {
                      var param = { param: 'p' + index }
                      if (angular.isObject(value))
                          for (var key in value) {
                              if (key == 0)
                                  param.param = value[0]
                              if (key == 1) {
                                  param.value = value[1]
                                  break
                              }
                          }
                      else
                          param.value = value;
                      return param;
                  }
                  function validateModel() {
                      if (angular.isDefined(attr.required) || angular.isDefined(attr.ngRequired)) {
                          controller.$setValidity("required", controller.$modelValue);
                      }
                      if (options.minRequired) {
                          if (angular.isArray(controller.$modelValue))
                              controller.$setValidity("min-required", controller.$modelValue.length >= options.minRequired);
                      }
                  }
                  function clearSelected() {
                      angular.forEach($select.optionData, function (item) {
                          item.selected = false;
                      })
                  }
                  return $select;
              }
              return SelectFactory;
          }
        ];
    })
    .provider('$tagsInput', function () {
        var defaults = this.defaults = {
            maxLength: 10,
            typeClass: 'tagsInput',
            navClass: 'nav-mixed',
            prefixEvent: 'tagsInput',
            allowedChars: '[A-Za-z0-9ŞşIıĞğÜüÇçÖö ]',
            clearStrict: true,
            placeholder: 'type...',
            modelIsLabel: true,
            preventDublication: true,
            caseSensitive: false,
            maxTextLength: 30,
            minTextLength: 3
        };
        this.$get = [
            '$select',
            '$filter',
          function ($select, $filter) {
              function TagsInputFactory(element, controller, config, attr, targetEl) {
                  if (config.directive != 'nqTagsInput') {
                      return new $select(element, controller, config, attr, targetEl)
                  }
                  var options = angular.extend({}, defaults, config);
                  options.trigger = false;
                  var $tagsInput = new $select(element, controller, options, attr, targetEl);
                  var init = $tagsInput.init, scope = $tagsInput.$scope;
                  $tagsInput.init = function () {
                      init();
                      $tagsInput.searchInput.on('keypress', $tagsInput.$onKeyEnter)
                      $tagsInput.searchInput.on('keypress', $tagsInput.$onKeyPress)
                  };
                  $tagsInput.$onKeyEnter = function (e) {
                      if (e.keyCode === 13) {
                          if (angular.isArray(controller.$modelValue) && !(controller.$modelValue.length < options.maxLength))
                              return false;
                          var label = scope.filterModel.label;
                          if (label && label.length >= options.minTextLength) {
                              if (label.length > options.maxTextLength)
                                  label = label.substr(0, label.length)
                              var newOpt = { label: label, value: label };
                              newOpt = $tagsInput.addOption(newOpt);
                              if (!newOpt.selected)
                                  $tagsInput.select(newOpt);
                              $tagsInput.searchInput.val('')
                          }
                      }
                  };
                  $tagsInput.$onKeyPress = function (e) {
                      var c = String.fromCharCode(e.which)
                      if (!(new RegExp('^' + options.allowedChars + '$').test(c)))
                          return false;
                  };
                  attr.nqTagsInput && scope.$parent.$watch(attr.nqTagsInput, function (newValue, oldValue) {
                      if (angular.isArray(newValue)) {
                          angular.forEach(newValue, function (val, index) {
                              if (angular.isObject(val)) {
                                  if (val.label || val.value) {
                                      var item = {
                                          label: val.label || val.value,
                                          value: val.value || val.label
                                      };
                                      $tagsInput.addOption(item);
                                      $tagsInput.changeOption('modelIsLabel', false)
                                  }
                              }
                              else {
                                  var item = {
                                      label: val,
                                      value: val
                                  };
                                  $tagsInput.addOption(item)
                              }
                          })
                      }
                  });
                  scope.$parent.$watch(attr.ngModel, function (newValue, oldValue) {
                      if (newValue) {
                          controller.$setViewValue(newValue)
                          $tagsInput.render();
                      }
                  });
                  return $tagsInput;
              }
              return TagsInputFactory;
          }
        ]
    })
    angular.forEach(['nqSelect', 'nqTagsInput'], function (directive) {
        selectApp.directive(directive, [
          '$compile',
          '$tagsInput',
          '$parseOptions',
          function ($compile, $tagsInput, $parseOptions) {
              return {
                  restrict: 'EAC',
                  scope: true,
                  require: ['ngModel', directive],
                  controller: function () {
                  },
                  link: function postLink(scope, element, attr, controllers) {

                      var options = {
                          $scope: scope
                      },
                      ngModel = controllers[0];

                      if (directive == 'nqTagsInput') {
                          options.displayType = 'input';
                          options.multiple = true;
                      }
                      options.directive = directive;

                      var targetEl = element;
                      if (attr.ngOptions)
                          options.grouped = attr.ngOptions.indexOf('group by') > -1;
                      else if (element.is('select'))
                          options.grouped = element.find('optgroup').length

                      if (element.is('select') || element.is('input')) {
                          targetEl.addClass('disable-animation')
                          targetEl.css('display', 'none');
                          buildElement()
                      }
                      else if (!angular.isDefined(attr.ngOptions)) {
                          buildElement()
                          targetEl.addClass('listbox');
                          var scroller = angular.element('<div tabindex="-1" class="scrollable" role="listbox"></div>');

                          scroller.append(targetEl.show());
                          options.targetElement = angular.element('<div tabindex="-1" role="listbox" class="listbox-panel"></div>').append(scroller);
                      }
                      else if (attr.qoDisplayType == 'input') {
                          buildElement();
                      }
                      var select = new $tagsInput(element, ngModel, options, attr, targetEl);
                      controllers[1].addOption = select.addOption;
                      controllers[1].changeOption = select.changeOption;
                      controllers[1].select = select.select;
                      ngModel.$render = select.render;
                      scope.$on('$destroy', function () {
                          select.destroy();
                          options = null;
                          select = null;
                      });
                      function buildElement() {
                          if (options.displayType == 'input' || attr.qoDisplayType == 'input') {
                              options.filterable = true;
                              element = angular.element('<ul class="nav nav-pills select-render-nav form-control"></ul>');
                              targetEl.hide()
                          }
                          else
                              element = angular.element('<button type="button" class="btn form-control">Please select...</button>');
                          targetEl.before(element);
                      }
                  }
              };
          }
        ]);
    });

    selectApp.directive('selectOption', [
      function () {
          return {
              restrict: 'AC',
              scope: true,
              require: '?^nqSelect',
              link: function postLink(scope, element, attr, controller) {
                  var itemkey, watcher, item = {};
                  if (angular.isDefined(attr.ngRepeat))
                      itemkey = attr.ngRepeat.split(' ')[0];
                  else if (angular.isDefined(element.parent().attr('ng-repeat') || element.parent().attr('data-ng-repeat'))) {
                      var parentattr = element.parent().attr('ng-repeat') || element.parent().attr('data-ng-repeat')
                      if (parentattr)
                          itemkey = parentattr.split(' ')[0];
                  }
                  watcher = itemkey + '.selected';
                  if (controller) {
                      scope.$watch(controller.changeOption, function (newValue, oldValue) {
                          if (angular.isDefined(controller.changeOption))
                              controller.changeOption('customFilter', true);
                      });
                      element.addClass('select-option')
                      element.attr('tabindex', -1)
                      element.attr('role', 'option')
                      item.label = scope.$eval(attr.optionLabel) || attr.optionLabel;
                      item.value = scope.$eval(attr.optionValue) || attr.optionValue || item.label;
                      scope.$watch(controller.changeOption, function (newValue, oldValue) {
                          if (angular.isDefined(controller.addOption))
                              scope._selectOption = controller.addOption(item);
                      });

                      watcher = '_selectOption.selected';
                      element.on('click', function () {
                          controller.select(scope._selectOption)
                      })
                      scope.$watch('_selectOption.filtered', function (newValue, oldValue) {
                          newValue ? element.hide() : element.show()
                      });
                  }
                  scope.$watch(watcher, function (newValue, oldValue) {
                      newValue ? element.addClass('selected') : element.removeClass('selected')
                  });
                  scope.$on('$destroy', function () {
                      element && element.remove();
                  });

              }
          };
      }
    ])
    selectApp.filter('groupOption', ['$filter', function ($filter) {
        return function (array) {
            if (!array || !array.length)
                return []
            var newArray = [];
            angular.forEach(array, function (value) {
                if (value.group)
                    addToGroup(value);
                else
                    newArray.push(value)
            })
            function addToGroup(value) {
                var group = $filter('filter')(newArray, function (gr) {
                    if (angular.isObject(value.group)) {
                        return gr.label === value.group.label;
                    }
                    else
                        return gr.label == value
                });
                if (group.length) {
                    group = group[0]
                    group.items.push(value)
                }
                else {
                    if (angular.isObject(value.group))
                        group = angular.copy(value.group);
                    else
                        group = { label: value };
                    group.items = []
                    group.items.push(value)
                    newArray.push(group)
                }
            }
            return newArray;
        };
    }]);
 }(window, window.angular);
'use strict';
angular.module('ngQuantum.slider', ['ngQuantum.services.mouse', 'ngQuantum.services.helpers'])
.provider('$slider', function () {
    var defaults = this.defaults = {
        keyboard: true,
        decimalPlace:0,
        step: 1,
        min: 0,
        max: 100,
        doubleThumb:false,
        diff: 10,
        size: false,
        sizeClass:false,
        showTooltip: true,
        tooltipVisible:false,
        showRuller: false,
        showLabel: false,
        tickSize: 10,
        valuePrefix: false,
        valueSuffix: false,
        formatValue:false,
        direction: 'horizontal',
        theme:false,
        thumbClass:false
    };
    this.$get = ['$rootScope', '$document', '$mouse', '$parse',
      function ($rootScope, $document, $mouse, $parse) {
          function Factory(element, config) {
              var $slider = {}, template, track, selection, thumb, thumb2, sizes, body = angular.element('body');
              
              var options = angular.extend({}, defaults, config);
              if (defaults.formatValue) {
                  options.callValueFunction = defaults.formatValue;
              }
              if (options.formatValue) {
                  options.formatValue = $parse(options.formatValue);
                  options.callValueFunction = false;
              }
              if (options.formatValue == false)
                  options.callValueFunction = false;
              var scope = $slider.$scope = options.$scope && options.$scope.$new() || $rootScope.$new();
              $slider.lastOffset = 0;
              $slider.lastOffset2 = 0;
              $slider.init = function () {
                  getTemplate();
                  template.addClass('slider-' + (options.direction == 'vertical' ? 'vertical' : 'horizontal'));
                  if (options.size) {
                      options.direction == 'vertical' ? template.height(options.size) : template.width(options.size)
                  }
                  options.sizeClass && template.addClass('slider-' + options.sizeClass)
                  findSizes();
                  bindMouse();
                  var titipclass = 'titip-' + (options.direction == 'vertical' ? 'left' : 'top') + ' titip-sm';
                  if (options.tooltipVisible) {
                      titipclass += ' titip-sm titip-active';
                  }
                 if (options.showTooltip || options.tooltipVisible) {
                     thumb.addClass(titipclass);
                     thumb2 && thumb2.addClass(titipclass);
                  }
                  if (options.doubleThumb)
                      options.direction == 'vertical' ? ($slider.lastOffset2 = sizes.trh) : ($slider.lastOffset2 = sizes.trw);
                  $slider.setValues();
                  if (options.showRuller || options.showLabel)
                      buildRuller();
                  
                  
              }
              $slider.setValues = function (value) {
                  if (!value) {
                      applyValue();
                      value = scope.values;
                  }
                  if (options.doubleThumb) {
                      if (!angular.isArray(value)) {
                          value = [value, options.max]
                      }
                      var v1 = (value[0] - options.min) / sizes.stepRate;
                      var v2 = (value[1] - options.min) / sizes.stepRate;
                      if (options.direction == 'vertical') {
                          v1 = v1 > sizes.trh ? sizes.trh : v1 < 0 ? 0 : v1;
                          bottomSlide(v1)
                          v2 = v2 > sizes.trh ? sizes.trh : v2 < 0 ? 0 : v2;
                          topSlide(v2)
                      }
                      else {
                          v1 = v1 > sizes.trw ? sizes.trw : v1 < 0 ? 0 : v1;
                          leftSlide(v1)
                          v2 = v2 > sizes.trw ? sizes.trw : v2 < 0 ? 0 : v2;
                          rightSlide(v2)
                      }
                  } else {
                      var v = (value - options.min) / sizes.stepRate;
                      if (options.direction == 'vertical') {
                          v = v > sizes.trh ? sizes.trh : v < 0 ? 0 : v;
                          bottomSlide(v)
                      }
                      else {
                          v = v > sizes.trw ? sizes.trw : v < 0 ? 0 : v;
                          leftSlide(v)
                      }
                  }
                  scope.$$postDigest(applyValue);
              }
              $slider.toggleDisable = function (disbled) {
                  if (disbled) {
                      template.addClass('slider-disabled')
                      unbindMouse();
                  }
                  else {
                      template.removeClass('slider-disabled');
                      unbindMouse();
                      bindMouse();
                  }
                  
              }
              $slider.destroy = function () {
                  unbindMouse();
                  scope.$destroy();
              }
              function applyValue(){
                  if (options.doubleThumb)
                      scope.values = [$slider.value0 || options.min, $slider.value1 || options.max];
                  else
                      scope.values = $slider.value0 || options.min;
              }
              function bindMouse() {
                  $mouse.down(track, function (event) {
                      if (event.target == track[0] || event.target == selection[0]) {
                          $slider.eventNo = 0;
                          slideThumb(event);
                      }
                  })
                  $mouse.down(thumb, function (event) {
                      $slider.eventNo = 1;
                      $mouse.move($document, slideThumb);
                      $mouse.up(body, documentUp)
                  })
                  thumb2 &&
                  $mouse.down(thumb2, function (event) {
                      $slider.eventNo = 2;
                      $mouse.move($document, slideThumb)
                      $mouse.up(body, documentUp)
                  })
                  
              }
              function unbindMouse() {
                  $mouse.offDown(track)
                  $mouse.offDown(thumb);
                  thumb2 && $mouse.offDown(thumb2);
                  $mouse.offMove($document, slideThumb);
                  $mouse.offUp(body, documentUp)
              }
              function documentUp(event) {
                  $mouse.offMove($document, slideThumb)
                  if (options.showTooltip && !options.tooltipVisible) {
                      thumb.removeClass('titip-active');
                      thumb2 && thumb2.removeClass('titip-active');
                  }
                  angular.element('body').removeClass('unselectable');
                  $mouse.offUp(body, documentUp);
                  
              }
              function slideThumb(event) {
                  event.preventDefault();
                  event.stopPropagation();
                  angular.element('body').addClass('unselectable')
                  if (!sizes)
                      findSizes();
                  if (options.showTooltip && !options.tooltipVisible) {
                      thumb.addClass('titip-active');
                      thumb2 && thumb2.addClass('titip-active');
                  }
                  options.direction == 'vertical' ? slideVertical(event) : slideHorizontal(event);
                  scope.$apply(applyValue)
                  
              }
              function slideVertical(event) {
                  var thumNo = 1;
                  var x = $mouse.relativeY(event, template);
                  x = sizes.trh - x;
                  x = x > sizes.trh ? sizes.trh : x < 0 ? 0 : x;
                  var val = (Math.abs(x - $slider.lastOffset) >= sizes.stepSize) || x == 0 || x == sizes.trh;
                  if ((options.doubleThumb && $slider.eventNo == 2) ||
                      (options.doubleThumb && $slider.eventNo == 0
                      && ((x > $slider.lastOffset2) || (Math.abs(x - $slider.lastOffset) > Math.abs(x - $slider.lastOffset2))))) {
                      val = (Math.abs(x - $slider.lastOffset2) >= sizes.stepSize) || x == 0 || x == sizes.trh;
                      thumNo = 2;
                  }
                  if (sizes.stepSize < 0 || val) {
                      thumNo == 2 ? topSlide(x) : bottomSlide(x);
                  }
              }
              function slideHorizontal(event) {
                  var thumNo = 1;
                  var x = $mouse.relativeX(event, template);
                  x = x > sizes.trw ? sizes.trw : x < 0 ? 0 : x;
                  var val = (Math.abs(x - $slider.lastOffset) >= sizes.stepSize) || x == 0 || x == sizes.trw;
                  if ((options.doubleThumb && $slider.eventNo == 2) ||
                      (options.doubleThumb && $slider.eventNo == 0
                      && ((x > $slider.lastOffset2) || (Math.abs(x - $slider.lastOffset) > Math.abs(x - $slider.lastOffset2))))) {
                      val = (Math.abs(x - $slider.lastOffset2) >= sizes.stepSize) || x == 0 || x == sizes.trw;
                      thumNo = 2;
                  }
                  if (sizes.stepSize < 0 || val) {
                      thumNo == 2 ? rightSlide(x) : leftSlide(x);
                  }
              }
              function leftSlide(x) {
                  if (sizes.diffPixel && ((x + sizes.diffPixel) > $slider.lastOffset2))
                      x = $slider.lastOffset2 - sizes.diffPixel + 1;
                  var value = getValue(x);
                  $slider.lastOffset = x;
                  thumb.css({ left: x });
                  options.showTooltip && thumb.attr('data-title', getValueFormat(value));
                  if (options.doubleThumb) {
                     var r = $slider.lastOffset2 > x ? (sizes.trw - $slider.lastOffset2) : 0;
                      selection.css({ left: x, right: r });
                  }
                  else
                      selection.css({ left: 0, right: sizes.trw - x });
                  $slider.value0 = value;
                  
              }
              function rightSlide(x) {
                  if (sizes.diffPixel && ((x - sizes.diffPixel) < $slider.lastOffset))
                      x = $slider.lastOffset + sizes.diffPixel;
                  var value = getValue(x);
                  $slider.lastOffset2 = x;
                  thumb2.css({ left: x });
                  options.showTooltip && thumb2.attr('data-title', getValueFormat(value));
                  var l = $slider.lastOffset > 0 ? $slider.lastOffset : 0;
                  selection.css({ right: sizes.trw - x, left: l });
                  $slider.value1 = value;
                  
              }

              function bottomSlide(x) {
                  if (sizes.diffPixel && ((x + sizes.diffPixel) > $slider.lastOffset2))
                      x = $slider.lastOffset2 - sizes.diffPixel + 1;
                  var value = getValue(x);
                  $slider.lastOffset = x;
                  thumb.css({ bottom: x });
                  options.showTooltip && thumb.attr('data-title', getValueFormat(value));
                  if (options.doubleThumb) {
                      var t = $slider.lastOffset2 > x ? (sizes.trh - $slider.lastOffset2) : 0;
                      selection.css({ bottom: x, top: t });
                  }
                  else
                      selection.css({ bottom: 0, top: sizes.trh - x });
                  $slider.value0 = value;

              }
              function topSlide(x) {
                  if (sizes.diffPixel && ((x - sizes.diffPixel) < $slider.lastOffset))
                      x = $slider.lastOffset + sizes.diffPixel;
                  var value = getValue(x);
                  $slider.lastOffset2 = x;
                  thumb2.css({ bottom: x });
                  options.showTooltip && thumb2.attr('data-title', getValueFormat(value));
                  var b = $slider.lastOffset > 0 ? $slider.lastOffset : 0;
                  selection.css({ bottom: b, top: sizes.trh - x });
                  $slider.value1 = value;

              }
              function getValue(val) {
                  if (!options.decimalPlace)
                      return Math.floor(val * sizes.stepRate) + parseFloat(options.min);
                  return parseFloat(Math.round(((val * sizes.stepRate) + parseFloat(options.min)) * 100) / 100).toFixed(options.decimalPlace)
              }
              function getValueFormat(val) {
                  if (options.callValueFunction)
                      return options.callValueFunction.call(null, val);
                  else if (options.formatValue)
                      return options.callValueFunction(scope, { $value: val });
                  else {
                      options.valuePrefix && (val = options.valuePrefix + val);
                      options.valueSuffix && (val += options.valueSuffix);
                      return val;
                  }
              }
              function findSizes() {
                  sizes = {
                      trw: track.width(),
                      thh: thumb.outerHeight(),
                      thw: thumb.outerWidth(),
                      trh: track.height()
                  }
                  var margins = {};
                  if (options.direction == 'vertical') {
                      margins['margin-bottom'] = -(sizes.thh / 2);
                      margins['margin-left'] = -((sizes.thw - sizes.trw) / 2);
                  }
                  else {
                      margins['margin-left'] = -(sizes.thw / 2);
                      margins['margin-top'] = -((sizes.thh - sizes.trh) / 2);
                  }
                  thumb.css(margins)
                  thumb2 && thumb2.css(margins)
                  findStep();
              }
              function findStep() {
                  var diff = (options.max - options.min) / options.step;
                  if (options.direction == 'vertical') {
                      sizes.stepRate = diff / sizes.trh;
                      sizes.stepSize = sizes.trh / diff;
                  } else {
                      sizes.stepRate = diff / sizes.trw;
                      sizes.stepSize = sizes.trw / diff;
                  }
                  options.diff && options.doubleThumb && (sizes.diffPixel = Math.round(sizes.stepSize * options.diff));
                  
              }
              function getTemplate() {
                  template = angular.element('<div class="range-slider"></div>').insertBefore(element).append(element)
                  track = angular.element('<div class="slider-track"></div>').appendTo(template);
                  selection = angular.element('<div class="slider-selection"></div>').appendTo(track);
                  thumb = angular.element('<div class="slider-thumb"></div>').appendTo(track);
                  options.theme && template.addClass('slider-' + options.theme)
                  options.thumbClass && thumb.addClass(options.thumbClass)
                  if (options.doubleThumb) {
                      thumb2 = angular.element('<div class="slider-thumb"></div>').appendTo(track);
                      options.thumbClass && thumb2.addClass(options.thumbClass)
                  }
                      
              }
              function buildRuller() {
                  var ruller = angular.element('<div class="slider-ruller"></div>').appendTo(template);
                  if (options.showRuller) {
                      var ticks = angular.element('<div class="slider-ticks"></div>').appendTo(ruller);
                      if (options.tickSize > 20)
                          options.tickSize = 20;
                      if (options.tickSize > 0)
                          for (var i = 0; i < options.tickSize - 1; i++) {
                              ticks.append('<span  class="slider-tick"></span>')
                          }
                  }
                  if(options.showLabel)
                      ruller.append('<div class="slider-values"><div class="values-min">' + getValueFormat(options.min) + '</div><div class="values-max">' + getValueFormat(options.max) + '</div></div>');

              }
              $slider.init();
              return $slider;
          }
          return Factory;
      }
    ];
})
.directive('nqSlider', ['$slider', '$helpers', function ($slider, $helpers) {
    return {
        restrict: 'AC',
        require: 'ngModel',
        link: function postLink(scope, element, attr, controller) {
            var options = {
                $scope : scope
            }
            var keys = ['disabled', 'keyboard', 'decimalPlace', 'step', 'min', 'max', 'doubleThumb', 'showLabel',
                        'diff', 'size', 'sizeClass', 'showRuller', 'direction', 'theme', 'thumbClass', 'valuePrefix', 'valueSuffix', 'formatValue']
            angular.forEach(keys,
                function (key) {
                    if (angular.isDefined(attr[key])) {
                        options[key] = $helpers.parseConstant(attr[key])
                    }

                });
            var slider = new $slider(element, options)
            scope.$watch(attr.ngModel, function (newVal, oldVal) {
                if (newVal) {
                    if (newVal != slider.$scope.values) {
                        slider.setValues(newVal);
                    }
                    
                }
            })
            attr.$observe('disabled', function (newVal, oldVal) {
                if (newVal) {
                    slider.toggleDisable(true);
                }
                else if(oldVal){
                    slider.toggleDisable(false);
                }
            })
            slider.$scope.$watch('values', function (newVal, oldVal) {
                if (newVal && (newVal !== oldVal)) {
                    controller.$setViewValue(newVal);
                }
            })
            scope.$on('$destroy', function () {
                slider.destroy();
                slider = null

            })
        }
    };
}])
'use strict';
angular.module('ngQuantum.switchButton', ['ngQuantum.services.helpers'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('switch/switchbutton.tpl.html',
                    '<div class="btn-group btn-switch">'
                        + '<label class="btn" ng-class="$buttonTheme"><span ng-class="{visibleswitch:$checked}" ng-bind-html="$trueLabel"></span><span class="switch-bg" ng-class="{visibleswitch:!$checked}"></span><span class="switch-label" ng-class="{visibleswitch:!$checked}" ng-bind-html="$labelText"></span></label>'
                        + '<label class="btn" ng-class="$buttonTheme"><span ng-class="{visibleswitch:!$checked}" ng-bind-html="$falseLabel"></span><span class="switch-bg" ng-class="{visibleswitch:$checked}"></span><span class="switch-label" ng-class="{visibleswitch:$checked}" ng-bind-html="$labelText"></span></label>'
                  + '</div>'
        )
    }])
    .provider('$switchButton', function () {
        var defaults = this.defaults = {
            trueLabel: 'ON',
            falseLabel: 'OFF',
            trueValue: true,
            falseValue: false,
            labelText: '&nbsp;',
            effect: 'slide-left',
            theme: 'default',
            btnSize: false
        };
        this.$get = function () {
            return { defaults: defaults };
        };
    })
    .directive('nqSwitchButton', ['$switchButton', '$helpers', function ($switchButton, $helpers) {
        return {
            restrict: 'AC',
            scope: {},
            templateUrl: 'switch/switchbutton.tpl.html',
            require: 'ngModel',
            link: function postLink(scope, element, attr, controller) {
                var button = element.children();
                element.after(button);
                element.hide();
                var options = angular.extend({}, $switchButton.defaults);
                angular.forEach(['theme', 'effect', 'btnSize'], function (key) {
                    if (angular.isDefined(attr[key])) {
                        options[key] = attr[key];
                    }
                });
                angular.forEach(['trueLabel', 'falseLabel', 'labelText'], function (key) {
                    if (angular.isDefined(attr[key])) {
                        options[key] = $helpers.parseConstant(attr[key])
                    }
                    scope['$' + key] = options[key];
                });
                options.effect && button.addClass(options.effect);
                !options.theme && (options.theme == 'default')
                if (options.theme) {
                    var themes = options.theme.split(','), newThemes = '';
                    for (var i = 0; i < themes.length; i++)
                        newThemes += 'btn-' + themes[i] + ' ';
                    scope.$$postDigest(function () {
                        scope.$buttonTheme = newThemes;
                    });
                }

                options.btnSize && button.addClass('btn-group-' + options.btnSize);
                var trueValue = options.trueValue || true, falseValue = options.falseValue || false;
                angular.isDefined(attr.ngTrueValue) && (trueValue = attr.ngTrueValue);
                angular.isDefined(attr.ngFalseValue) && (trueValue = attr.ngFalseValue);


                scope.$parent.$watch(attr.ngModel, function (newVal, oldVal) {
                    if (newVal == trueValue && !scope.$checked) {
                        scope.$checked = true;
                    }
                    else if (newVal == falseValue && scope.$checked) {
                        scope.$checked = false;
                    }
                })
                button.on('click', function (e) {
                    if (scope.$disabled) {
                        e.preventDefault();
                        return false;
                    }
                    scope.$apply(function () {
                        attr.$set('checked', !scope.$checked)
                    });
                })
                attr.$observe('checked', function (newVal, oldVal) {
                    scope.$checked = newVal;
                    if (newVal)
                        controller.$setViewValue(trueValue);
                    else
                        controller.$setViewValue(falseValue);
                })
                attr.$observe('disabled', function (newVal, oldVal) {
                    scope.$disabled = newVal;
                    if (scope.$disabled)
                        button.addClass('btn-disabled')
                    else
                        button.removeClass('btn-disabled')
                })
                scope.$on('$destroy', function () {
                    button.off('click');
                    button = null;
                    options = null;
                })
            }
        };
    }])
'use strict';
angular.module('ngQuantum.tabset', ['ngQuantum.services.helpers'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';
        $templateCache.put('tabs/tabset.tpl.html',
                 '<div class="tab-container {{theme}}">'
                   + '<ul class="nav {{navClasses}}" nav-placement="{{placement}}">'
                   + '<li ng-repeat="pane in panes | orderBy:$paneindex" ng-class="{active: pane.active, disabled: pane.disabled}">'
                       + '<a role="button" tabindex="0" tab-heading-transclude="pane">{{pane.heading}}</a>'
                   + '</li>'
                   + '</ul>'
                   + '<div class="tab-content clearfix" ng-transclude></div>'
               + '</div>'
        );
        $templateCache.put('tabs/tabset.responsive.tpl.html',
                '<div class="tab-container {{theme}}">'
                 + '<ul class="nav {{navClasses}}" nav-placement="{{placement}}">'
                 + '<li ng-repeat="pane in panes" ng-show="!pane.stored"  ng-class="{active: pane.active, disabled: pane.disabled}">'
                     + '<a role="button" tabindex="0" tab-heading-transclude="pane">{{pane.heading}}</a>'
                 + '</li>'
                 + '<li ng-show="showMore">'
                    + '<a role="button" tabindex="0" nq-dropdown="" class="dropdown-toggle" data-placement="{{ddPlacement}}">More</a>'
                     + '<ul class="dropdown-menu">'
                         + '<li ng-repeat="pane in panes | filter:{stored:true}" ng-class="{active: pane.active, disabled: pane.disabled}">'
                              + '<a role="button" tabindex="0" ng-click="pane.select()" ng-bind-html="pane.htmlString"></a>'
                         + '</li>'
                     + '</ul>'
                 + '</li>'
                 + '</ul>'
                 + '<div class="tab-content" ng-transclude></div>'
               + '</div>'
        );
    }])
    .provider('$tabset', function () {
        var defaults = this.defaults = {
            effect: 'slide-right-left',
            type: 'tabs',
            speed: 'fastest',
            placement: 'top',
            justified: false,
            prefixEvent: 'tabs',
            directive: 'nqTab',
            instanceName: 'tabs',
            fireEmit: false,
            fireBroadcast: false,
            keyboard: false,
            theme: false,
            trigger: 'click',
            responsive: true,
            delay: 0
        };
        this.$get = ['$timeout', '$filter', '$compile', '$sce', '$animate',
          function ($timeout, $filter, $compile, $sce, $animate) {
              function TabFactory($scope, config) {

                  var $tabset = {},
                  options = $tabset.$options = angular.extend({}, defaults, config),

                  panes = $tabset.panes = $scope.panes = [];
                  var nc = 'nav-' + options.type;
                  if (options.justified)
                      nc = nc + ' nav-justified'
                  else if (/right|left/.test(options.placement)) {
                      nc = nc + ' nav-stacked'
                      options.responsive = false;
                  }
                  $scope.ddPlacement = 'bottom-right'
                  $scope.navClasses = nc
                  $scope.theme = (options.theme && 'nav-' + options.theme) + ' tab-' + options.placement;
                  $scope.placement = options.placement;
                  if (options.placement == "bottom")
                      $scope.ddPlacement = 'top-right'
                  $tabset.select = function (selectedPane) {
                      angular.forEach(panes, function (pane) {
                          if (pane.active && pane !== selectedPane) {
                              pane.active = false;
                              pane.activeClasses = '';
                              pane.onDeselect();
                          }
                      });
                      selectedPane.active = true;
                      selectedPane.onSelect();
                  };

                  $tabset.addPane = function (pane) {
                      panes.push(pane);
                      if (panes.length === 1) {
                          pane.active = true;
                      } else if (pane.active) {
                          $tabset.select(pane);
                      }
                      $tabset.lastStoredIndex++;
                  };
                  $tabset.removePane = function (pane) {
                      var index = panes.indexOf(pane);
                      if (pane.active && panes.length > 1) {
                          var newActiveIndex = index == panes.length - 1 ? index - 1 : index + 1;
                          $tabset.select(panes[newActiveIndex]);
                      }
                      panes.splice(index, 1);
                  };

                  $tabset.panesWidth = 0;
                  $tabset.lastStoredIndex = -1;
                  return $tabset;
              }
              return TabFactory;
          }
        ];
    })
    .directive('nqTabset', ['$tabset', '$compile', '$timeout', '$helpers',function ($tabset, $compile, $timeout, $helpers) {
        return {
            restrict: 'EA',
            transclude: true,
            replace: true,
            scope: {},
            templateUrl: function (element, attr) {
                if(angular.isDefined(attr.template))
                    return attr.template;
                if (attr.responsive && !/right|left/.test(attr.placement))
                    return 'tabs/tabset.responsive.tpl.html';
                return 'tabs/tabset.tpl.html';
            },
            controller: ['$scope', '$element', '$attrs', function ($scope, $element, $attrs) {
                var that = this;
                var options = {};
                angular.forEach(['theme', 'justified', 'effect', 'type', 'speed', 'placement', 'keyboard', 'trigger', 'responsive'],
                    function (key) {
                        angular.isDefined($attrs[key]) && (options[key] = $helpers.parseConstant($attrs[key]))
                    })
                var ctrl = new $tabset($scope, options);
                that = angular.extend(that, ctrl);
                if ($attrs.tabsetModel)
                    $scope.$parent[$attrs.tabsetModel] = that;
                return that;
            }],

            link: function postLink(scope, elm, attrs, controller, transcludeFn) {
                attrs.nqTabset && scope.$parent.$watch(attrs.nqTabset, function (newValue, oldValue) {
                    var content = elm.find('.tab-content');
                    if (newValue && newValue.length && content.length) {
                        for (var j = 0; j < newValue.length; j++) {
                            var paneelm = angular.element('<div data-nq-tab=""></div>').append('<span data-tab-heading="">' + newValue[j].heading + '</span>')
                                                 .append(newValue[j].content)
                            content.append(paneelm)
                            $compile(paneelm)(scope)
                        }
                    }
                }, true);
                if (controller.$options.responsive) {
                    scope.$watch(function () { return elm.width(); }, function (newValue, oldValue) {
                        setTimeout(function () {
                            scope.$apply(function () {
                                responsiveDesign(elm.innerWidth() - 90, newValue)
                            });
                        }, 0)
                    });
                    
                }
                function responsiveDesign(value, oldValue) {
                    !oldValue && (oldValue = 0)
                    !value && (value = 0)
                    var dif = Math.abs(controller.panesWidth - value)
                    if (!value || !controller.panes.length || dif < 10)
                        return;
                    if (value < controller.panesWidth) {
                        if (controller.panes.length <= controller.lastStoredIndex || controller.lastStoredIndex == -1)
                            controller.lastStoredIndex = controller.panes.length - 1;
                        while (value < controller.panesWidth && controller.lastStoredIndex > 0) {
                            var p = controller.panes[controller.lastStoredIndex];

                            if (!p.stored) {
                                controller.panesWidth -= p.widht;
                                p.stored = true;
                                scope.showMore = true;
                            }
                            controller.lastStoredIndex--
                        }
                    }
                    else if (value > controller.panesWidth) {
                        while (value > controller.panesWidth && controller.panes.length > controller.lastStoredIndex) {
                            var p = controller.panes[controller.lastStoredIndex];
                           
                            if (p && p.stored == true) {
                                controller.panesWidth += p.widht;
                                p.stored = false;
                            }

                            controller.lastStoredIndex++;
                            (controller.panes.length == controller.lastStoredIndex) && (scope.showMore = false)
                        }
                    }
                }

            }
        };
    }])
    .directive('nqTab', ['$parse', '$timeout', function ($parse, $timeout) {
        return {
            require: '^nqTabset',
            restrict: 'EA',
            replace: true,
            template: '<div class="tab-pane clearfix" tab-content-transclude=""></div>',
            transclude: true,
            scope: {
                heading: '@',
                onSelect: '&select',
                onDeselect: '&deselect'
            },
            controller: function () {
            },
            compile: function (elm, attrs, transclude) {
                return function postLink(scope, elm, attrs, controller) {
                    scope.effect = controller.$options.effect;
                    scope.speed = controller.$options.speed;
                    angular.isDefined(attrs.effect) && (scope.effect = attrs.effect)
                    angular.isDefined(attrs.speed) && (scope.effect = attrs.speed)
                    if (angular.isDefined(attrs.active)) {
                        scope.$$postDigest(function () {
                            scope.select()
                        });
                    }
                    scope.$watch('active', function (active) {
                        if (active) {
                            controller.select(scope);
                        }
                    });

                    scope.disabled = false;
                    if (attrs.disabled) {
                        scope.$parent.$watch($parse(attrs.disabled), function (value) {
                            scope.disabled = !!value;
                        });
                    }

                    scope.select = function () {
                        if (!scope.disabled) {
                            scope.active = true;
                        }
                    };
                    scope.$paneindex = elm.index() || scope.$index;;
                    controller.addPane(scope);
                    scope.$on('$destroy', function () {
                        controller.removePane(scope);
                    });

                    $timeout(function () {
                        scope.$transcludeFn = transclude;
                    }, 0)
                    
                };
            }
        };
    }])
    .directive('tabHeadingTransclude', ['$compile',function ($compile) {
        return {
            restrict: 'A',
            require: '^nqTabset',
            link: function (scope, elm, attrs, controller) {
                var pane = scope.$eval(attrs.tabHeadingTransclude);
                scope.$watch(function () { return pane.headingElement }, function (heading) {
                    if (heading) {
                        elm.html($compile(angular.element(heading))(scope));
                        pane.widht = elm.parent().outerWidth(true);

                    }
                    else
                        pane.widht = elm.parent().outerWidth(true);
                    if (pane.oldWidth)
                        controller.panesWidth -= pane.oldWidth;
                    pane.oldWidth = pane.widht
                    controller.panesWidth += pane.widht;
                    pane.htmlString = elm.html();
                });
                elm.on('click', function (evt) {
                    evt.preventDefault();
                    evt.stopPropagation();
                    console.log(pane)
                    if (pane.active) return;

                    scope.$apply(function () {
                        pane.select();
                    })
                })
            }
        };
    }])
    .directive('navPlacement', [function () {
        return {
            restrict: 'A',
            require: '^nqTabset',
            link: function (scope, elm, attrs, controller) {
                attrs.$observe('navPlacement', function (value) {
                    if (/bottom|right/.test(value)) {
                        elm.parent().append(elm)
                    }
                })
            }
        };
    }])
   
    .directive('tabContentTransclude', ['$animate', '$timeout', function ($animate, $timeout) {
        return {
            restrict: 'A',
            require: '^nqTab',
            link: function (scope, elm, attrs, controller) {
                scope.$watch('$transcludeFn', function (value) {
                    value && scope.$transcludeFn(scope.$parent, function (contents) {
                        angular.forEach(contents, function (node, i) {
                            if (isTabHeading(node)) {
                                scope.headingElement = node;
                            } else {
                                elm.append(node);
                            }
                        });
                            
                    });
                });
                scope.$watch('active', function (value) {
                    value ? show() : hide();
                });
                function show() {
                    elm.css('display', 'block');
                    elm.css('visibility', 'visible');
                    if (scope.effect) {
                        elm.addClass(scope.speed);
                        var content = elm.closest('.tab-content');
                        content.css('overflow', 'hidden');
                        $animate.addClass(elm, scope.effect).then(function () {
                            content.css('overflow', '')
                        });
                    }

                }
                function hide() {
                    elm.css('visibility', 'hidden');
                    elm.css('display', 'none');
                    if (scope.effect) {
                        elm.removeClass(scope.speed)
                        elm.removeClass(scope.effect)
                    }
                }
            }
        };
        function isTabHeading(node) {
            return node.tagName && (
              node.hasAttribute('tab-heading') ||
              node.hasAttribute('data-tab-heading') ||
              node.tagName.toLowerCase() === 'tab-heading' ||
              node.tagName.toLowerCase() === 'data-tab-heading'
            );
        }
    }]);

'use strict';
angular.module('ngQuantum.tooltip', ['ngQuantum.popMaster'])
    .run(['$templateCache', function ($templateCache) {
        'use strict';

        $templateCache.put('tooltip/tooltip.tpl.html',
          "<div class=\"tooltip in\" ng-show=\"title\"><div class=\"tooltip-arrow\"></div><div class=\"tooltip-inner\" ng-bind=\"title\"></div></div>"
        );

    }])
    .provider('$tooltip', function () {
        this.$get = [
          '$sce',
          '$rootScope',
          '$popMaster', '$helpers',
          function ($sce, $rootScope, $popMaster, $helpers) {
              var defaults = this.defaults = {
                  title: false,
                  template: 'tooltip/tooltip.tpl.html',
                  directive: 'nqTooltip',
                  typeClass: 'tooltip',
                  prefixEvent: 'tooltip',
                  container: 'body',
                  displayReflow: true,
                  autoDestroy: false,
                  forceHide: true,
                  clearExists: false,
              }
              function TooltipFactory(element, config, attr) {
                  var $tooltip = {};
                  config = $helpers.parseOptions(attr, config);
                  var options = config = angular.extend({}, defaults, config);

                  $tooltip = new $popMaster(element, options);
                  var scope = $tooltip.$scope
                  options = $tooltip.$options = $helpers.observeOptions(attr, $tooltip.$options);
                  if (options.title) {
                      scope.title = options.title;
                  }

                  if (attr) {
                      attr.qsTitle && (scope.title = attr.qsTitle);
                      attr.$$observers && attr.$$observers.qsTitle && attr.$observe('qsTitle', function (newValue, oldValue) {
                          scope.title = newValue;
                          angular.isDefined(oldValue) && $tooltip.$applyPlacement();
                      });
                  }
                  scope.$on('$destroy', function () {
                      $tooltip && $tooltip.destroy();
                      $tooltip = null;
                  });
                  return $tooltip;
              }
              return TooltipFactory;
          }
        ];
    })
    .directive('nqTooltip', [
      '$tooltip',
      function ($tooltip) {
          return {
              restrict: 'EAC',
              link: function postLink(scope, element, attr, transclusion) {
                  var options = {
                      $scope: scope.$new()
                  };
                  if (element[0].tagName.toLowerCase() == 'input')
                      options.isInput = true;
                  var tooltip = $tooltip(element, options, attr);
                  scope.$on('$destroy', function () {
                      options.$scope.$destroy();
                  })
              }
          };
      }
    ]);

'use strict';
angular.module('ngQuantum', [
  'ngQuantum.directives',
  'ngQuantum.tooltip',
  'ngQuantum.aside',
  'ngQuantum.dropdown',
  'ngQuantum.modal',
  'ngQuantum.modalBox',
  'ngQuantum.alert',
  'ngQuantum.popover',
  'ngQuantum.button',
  'ngQuantum.loading',
  'ngQuantum.loadingButton',
  'ngQuantum.tabset',
  'ngQuantum.carousel',
  'ngQuantum.collapse',
  'ngQuantum.select',
  'ngQuantum.datepicker',
  'ngQuantum.scrollbar',
  'ngQuantum.colorpicker',
  'ngQuantum.switchButton',
  'ngQuantum.slider'
    ]);