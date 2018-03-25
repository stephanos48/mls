
(function () {

    "use strict";

    angular.module("app-uploader")
           .factory("entityService",
           ["akFileUploaderService", function (akFileUploaderService) {
               var saveTutorial = function (tutorial) {
                   return akFileUploaderService.saveModel(tutorial, "/controllerName/actionName");
               };
               return {
                   saveTutorial: saveTutorial
               };
           }]);

})();