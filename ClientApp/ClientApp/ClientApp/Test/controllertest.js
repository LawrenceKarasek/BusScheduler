
describe('app: ClientApp', function () {
    beforeEach(module('ClientApp'));
    var $controller;
    beforeEach(inject(function (_$controller_) {
        $controller = _$controller_;
    }));
    // Factory of interest is called MyFactory
    describe('factory: DataService', function () {
        var factory = null;
        beforeEach(inject(function (DataService) {
            factory = DataService;
        }))
        it('Test Data Service Stop 1', function () {
                factory
                      .getData(1)
                      .then(function(res) {
                          expect(res.Length).toBe(6);
                      });
        });

        it('Test Data Service Stop 5', function () {
            factory
                  .getData(5)
                  .then(function (res) {
                      expect(res.Length).toBe(6);
                  });
        });

        it('Test Data Service Stop 10', function () {
            factory
                  .getData(10)
                  .then(function (res) {
                      expect(res.Length).toBe(6);
                  });
        });
    });

});
