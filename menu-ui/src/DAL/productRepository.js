import RepositoryBase from "./repositoryBase";

export default class ProductRepository extends RepositoryBase {
    constructor() {
        super();

        this.endPoint = this.endPoint + "/product";
    }

    async getAll(restaurantName) {
        let response = await fetch(this.endPoint + "/" + restaurantName, {
            method: "GET",
            headers: new Headers({
                'Authorization': 'Bearer ' + localStorage.getItem('token'),
            })
        });
        let data = [];

        if (response.status === 200) {
            data = await response.json();
        }

        return data;
    }
}