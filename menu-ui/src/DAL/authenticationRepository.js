import RepositoryBase from "./repositoryBase";

export default class AuthenticationRepository extends RepositoryBase {
    constructor() {
        super();

        this.endPoint += "/token";
    }

    async getToken(restaurantId = 1, tableId = 1) {
        let response = await fetch(this.endPoint + "?restaurantId=" + restaurantId + "&" + "tableId=" + tableId);
        let data = await response.json();

        if (response.status === 200) {
            localStorage.setItem("token", data.token);
            return true;
        }

        return false;
    }

    async isAuthorized() {
        return !!localStorage.getItem("token");
    }

    async checkout() {
        localStorage.removeItem("token");
    }
}