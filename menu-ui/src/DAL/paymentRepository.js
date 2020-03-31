import RepositoryBase from "./repositoryBase";

export default class PaymentRespository extends RepositoryBase {
    constructor() {
        super();

        this.endPoint += "/payment";
    }
}