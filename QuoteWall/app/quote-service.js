angular.module('quote-wall-app', [])
    .service('QuoteService', ['$http', function ($http) {

      var urlBase = 'http://localhost:4080/api/quotes';

      this.getQuotes = function () {
        return $http.get(urlBase);
      };

      this.getQuote = function (id) {
        return $http.get(urlBase + '/' + id);
      };

      this.insertQuote = function (quote) {
        return $http.post(urlBase, quote);
      };

      this.updateQuote = function (quote) {
        return $http.post(urlBase, quote);
      };

      this.deleteQuote = function (id) {
        return $http.delete(urlBase + '/' + id);
      };

      //this.getOrders = function (id) {
      //  return $http.get(urlBase + '/' + id + '/orders');
      //};
    }]);