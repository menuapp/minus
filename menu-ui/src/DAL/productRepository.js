import RepositoryBase from "./repositoryBase";

export default class ProductRepository extends RepositoryBase {
    constructor() {
        super();

        this.endPoint = this.endPoint + "/product";
    }

    async getAll(restaurantName) {
        let response = await fetch(this.endPoint + "/" + restaurantName);
        let data = await response.json();

        return data;
    }
}