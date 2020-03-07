import RepositoryBase from './repositoryBase';

export default class OrderRepository extends RepositoryBase {
    constructor() {
        super();

        this.endPoint += '/basket';
    }

    async addToBasket() {
        let response = await fetch(this.endPoint + '/add', {
            method: 'POST',
            body: {
                CounterId: 1,
                PartnerId: 1
            }
        });
        let data = await response.json();

        return data;
    }
}