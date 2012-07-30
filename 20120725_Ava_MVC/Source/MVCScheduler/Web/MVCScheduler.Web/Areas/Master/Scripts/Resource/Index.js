function ResourceViewModel(data) {
    this.id = ko.observable(data.id);
    this.code = ko.observable(data.code);
    this.name = ko.observable(data.name);
    this.resourceTypeID = ko.observable(data.resourceTypeID);
}

function ResourceListViewModel() {
}