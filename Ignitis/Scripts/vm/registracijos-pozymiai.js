
// Vienos lentelės eilutės reprezentacija
var RegPozymisVM = function (data) {
    var self = this;

    self.regPozId = ko.observable(data.RegPozId);
    self.pavadinimas = ko.observable(data.Pavadinimas);

    self.regPozKlasifikId = ko.observable(data.RegPozKlasifikId);

    self.klasifikatorius = ko.observable(data.Klasifikatorius); // Dropdauno itemai
    self.klasifikId = ko.observable(data.KlasifikId); // Pasirinkta dropdauno reikšmė
}

var RegistracijosPozymiaiViewModel = function () {
    var self = this;

    self.registracijosPozymiai = ko.observableArray([]); // Lentelės eilutės
    self.registracijosPozymiaiOrig = ko.observableArray([]); // Lentelės originalo kopija

    //Seivas
    self.issaugotiPataisymusClick = function () {

        var rp = ko.toJS(self.registracijosPozymiai());

        ajaxHelper("/Home/StoreRegistracijosPozymiai", "POST", rp).done(function (result) {
            self.koreguotiPozymius(false);
            alert('Sėkmingai išsaugota :)')
        }).fail(function (jqXHR, textStatus, errorThrown) {

        });
    }

    self.koreguotiPozymius = ko.observable(false);
    self.koreguotiPozymiusClick = function () {
        // Pasiklonuojame lentele, kad turėtume originalą, jei paspausime mygtuką "Atšaukti pataisymus"
        self.registracijosPozymiaiOrig(cloneObservable(self.registracijosPozymiai));
        self.koreguotiPozymius(true);
    }

    self.atsauktiPataisymusClick = function () {
        // Atstatome lentele is klono
        self.registracijosPozymiai(cloneObservable(self.registracijosPozymiaiOrig));
        self.koreguotiPozymius(false);
    }
}

var vm = new RegistracijosPozymiaiViewModel();
ko.applyBindings(vm);

// Užsikrauname lentelę
ajaxHelper("/Home/GetRegistracijosPozymiai", "GET", null).done(function (result) {
    vm.registracijosPozymiai(ko.observableArray().map(result, RegPozymisVM));
}).fail(function (jqXHR, textStatus, errorThrown) {
    // Sorry, palieku fantazijai :)
});

