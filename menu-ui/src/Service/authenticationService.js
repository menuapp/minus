import ServiceBase from './serviceBase';
import AuthenticationRepository from '../DAL/authenticationRepository';

export default class AuthenticationService extends ServiceBase {
    constructor() {
        super();
        this.authenticationRepository = new AuthenticationRepository();
    }

    async getToken(restaurantName, table) {
        return await this.authenticationRepository.getToken(restaurantName, table);
    }
}