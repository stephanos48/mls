// MovieService.
app.service("IncomingTopLevelService", function ($http) {

    // Get Movies.
    this.getIncomingTopLevels = function (d) {
        //return $http.get('/api/MovieAPI');
        return $http({
            method: 'GET',
            url: '/api/IncomingTopLevelAPI',
            headers: { 'content-type': 'application/json' },
            dataType: 'json',
        })
    };

    // Add Movie.
    this.addIncomingTopLevel = function (incomingtoplevel) {
        var request = $http({
            method: 'POST',
            url: '/api/IncomingTopLevelAPI',
            data: incomingtoplevel
        });

        return request;
    }

    // Get Movie.
    this.getIncomingTopLevel = function (id) {
        return $http({
            method: 'GET',
            url: '/api/IncomingTopLevelAPI/' + id
            //data: { 'Id': d.Id },
        });
    };

    // Update Movie.
    this.updateIncomingTopLevel = function (id, IncomingTopLevel) {
        return $http({
            method: 'PUT',
            url: '/api/IncomingTopLevelAPI/' + id,
            data: IncomingTopLevel
        });
    };

    // Delete Movie.
    this.deleteIncomingTopLevel = function (id) {
        return $http({
            method: 'DELETE',
            url: '/api/IncomingTopLevelAPI/' + id
        });
    };

});