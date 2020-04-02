import RepositoryBase from "./repositoryBase";

export default class PaymentRepository extends RepositoryBase {
    constructor() {
        super();

        this.paymentEndPoint = this.endPoint + "/payment";
        this.endPoint += "/basket";

    }

    async choosePaymentMethod(order) {
        // switch (paymentType) {
        //   case paymentTypes.CARD:
        //     order.paymentType = paymentTypes.CARD;
        //     break;
        //   case paymentTypes.MOBILE:
        //     break;
        //   case paymentTypes.CASH:
        //     break;
        // }

        let response = await fetch(this.endPoint + '/choosepayment', {
            method: 'POST',
            headers: new Headers({
                Accept: 'application/json',
                'Content-Type': 'application/json',
                Authorization: 'Bearer ' + localStorage.getItem('token')
            }),
            body: JSON.stringify(order)
        });

        if (response.status === 200) {
            return true;
        } else {
            return false;
        }
    }

    async payOnline(order) {
        let response = await fetch(this.paymentEndPoint, {
            method: 'POST',
            headers: new Headers({
                Accept: 'application/json',
                'Content-Type': 'application/json',
                Authorization: 'Bearer ' + localStorage.getItem('token')
            }),
            body: JSON.stringify({
                cardHolderName: "Mehmet Akif Özkan",
                cardNumber: "5311570000000005",
                expireMonth: "12",
                expireYear: "2030",
                cvc: "123",
                basket: order
            })
        });

        if (response.status === 200) {
            return true;
        } else {
            return false;
        }
    }
}