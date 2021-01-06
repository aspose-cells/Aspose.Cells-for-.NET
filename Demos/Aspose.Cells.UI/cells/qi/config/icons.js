angular.module('ngQuantum').config(
    ['$datepickerProvider',
     '$loadingButtonProvider',
     '$colorPickerProvider',
     '$loadingProvider',
     '$modalProvider',
     '$modalBoxProvider',
     '$selectProvider',
     '$alertProvider',
      function ($datepickerProvider, $loadingButtonProvider, $colorPickerProvider, $loadingProvider, $modalProvider, $modalBoxProvider, $selectProvider, $alertProvider) {
          var dpdef = $datepickerProvider.defaults,
              lbdef = $loadingButtonProvider.defaults,
              cpdef = $colorPickerProvider.defaults,
              ldef = $loadingProvider.defaults,
              mdef = $modalProvider.defaults,
              mbdef = $modalBoxProvider.defaults,
              sdef = $selectProvider.defaults,
              adef = $alertProvider.defaults;
          //datepicker icons
          dpdef.todayIcon = 'fic glyphicon glyphicon-refresh';
          dpdef.nextIcon = 'fic glyphicon glyphicon-chevron-right';
          dpdef.prevIcon = 'fic glyphicon glyphicon-chevron-left';
          dpdef.timeIcon = 'fic glyphicon glyphicon-time';
          dpdef.closeIcon = 'fic glyphicon glyphicon-remove';
          dpdef.downIcon = 'fic glyphicon glyphicon-chevron-down';
          dpdef.upIcon = 'fic glyphicon glyphicon-chevron-up';

          //loadingButton icons
          lbdef.spinner = '<i class="fic glyphicon glyphicon-repeat spin"></i> '; //any html accepted
          lbdef.successIcon = '<i class="fic glyphicon fu-check  flash"></i>'; //any html accepted
          lbdef.errorIcon = '<i class="fic glyphicon glyphicon-ok flash red"></i> '; //any html accepted
          lbdef.timeoutIcon = '<i class="fic glyphicon glyphicon-bell"></i> '; //any html accepted

          //colorpicker icons
          cpdef.iconDown = 'fic glyphicon glyphicon-menu-down';
          cpdef.iconUp = 'fic glyphicon glyphicon-menu-up';
          adef.closeIcon = 'fic glyphicon glyphicon-remove';

          //loading service icons
          ldef.spinnerIcon = '<i class="fic glyphicon glyphicon-repeat spin-icon spin"></i>'; //any html accepted

          //modal icons
          mdef.closeIcon = '<i class="fic glyphicon glyphicon-remove"></i>'; //any html accepted

          //select icons
          sdef.clearIcon = '<i class="fic clear-icon glyphicon glyphicon-remove"></i>'; //any html accepted
          sdef.spinner = '<i class="fic glyphicon glyphicon-repeat spin"></i>'; //any html accepted

          mbdef.effect = 'from-top';

    }])
