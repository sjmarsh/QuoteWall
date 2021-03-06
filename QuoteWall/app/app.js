﻿  var app = angular.module('quote-wall-app')
    .controller('QuoteController', ["$scope", 'QuoteService', function ($scope, QuoteService) {

    $scope.status;
    $scope.quotes = [];
    $scope.quoteDetail;
    
    $scope.detailVisible = false;

    getQuotes();

    $scope.addQuote = function () {
      var newQuote = {
        QuoteText: $scope.newQuote.quoteText,
        Quoter: $scope.newQuote.quoter,
        DateAdded: new Date(),
        Rating: 0
      };

      $scope.saving = true;
      QuoteService.insertQuote(newQuote)
        .success(function () {
          $scope.saving = false;
          $scope.quotes.push(newQuote);
        })
        .error(function () {
          $scope.saving = false;
          $scope.status = "Error saving Quote";
        });
    };

    $scope.voteUp = function (quote) {
      quote.Rating++;
      QuoteService.updateQuote(quote)
        .success(function () {
        })
        .error(function () {
          $scope.status = "Error saving Quote Rating";
        });
    };

    $scope.voteDown = function (quote) {
      quote.Rating--;
      QuoteService.updateQuote(quote)
        .success(function () {
        })
        .error(function () {
          $scope.status = "Error saving Quote Rating";
        });
    }
         
    function getQuotes() {
      QuoteService.getQuotes()
        .success(function (quotes) {
          quotes = quotes.sort(function(a, b){
            return b.Rating - a.Rating;
          })

          $scope.quotes = quotes;
        })
        .error(function (error) {
          $scope.status = 'Unable to load quote data. ' + error.message;
        });
    };

    function getQuote(id) {
      QuoteService.getQuote(id)
        .success(function (quote) {
          $scope.quoteDetail = quote;
          $scope.detailVisible = true;
        })
        .error(function (error) {
          $scope.status = 'Unable to load quote data. ' + error.message;
        });
    };

    }]);