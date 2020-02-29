import ServiceBase from "./serviceBase";
import ProductRepository from "../DAL/productRepository";

export default class ProductService extends ServiceBase {
    constructor() {
        super();
        this.productRepository = new ProductRepository();
    }

    async getAll(restaurantName) {
        let products = [{
                "id": 1,
                "name": "Starters",
                "products": [{
                        "id": 1,
                        "name": "Soup",
                        "unitPrice": 4.50,
                        "rating": 0.0,
                        "contents": [{
                            "relativePath": "localhost/AdminUI/uploads/3a30e9440c824ed6a4acd2eff3193609.jpg"
                        }],
                        "description": null
                    },
                    {
                        "id": 4,
                        "name": "Borek",
                        "unitPrice": 2.40,
                        "rating": 0.0,
                        "contents": [{
                            "relativePath": "localhost/AdminUI/uploads/0b001bbbba4d41969e31edb98c059b35.jpg"
                        }],
                        "description": null
                    },
                    {
                        "id": 5,
                        "name": "Garlic Bread",
                        "unitPrice": 2.99,
                        "rating": 0.0,
                        "contents": [{
                            "relativePath": "localhost/AdminUI/uploads/63e034e35f0647a4868900e06ff07fa5.jpeg"
                        }],
                        "description": null
                    },
                    {
                        "id": 6,
                        "name": "Macaron",
                        "unitPrice": 2.00,
                        "rating": 0.0,
                        "contents": [{
                            "relativePath": "localhost/AdminUI/uploads/528ef57ff0be4ada993f725357c1d8c6.jpg"
                        }],
                        "description": null
                    }
                ]
            },
            {
                "id": 2,
                "name": "Salads",
                "products": [{
                        "id": 2,
                        "name": "Ceasar Salad",
                        "unitPrice": 10.50,
                        "rating": 0.0,
                        "contents": [{
                            "relativePath": "localhost/AdminUI/uploads/479703583e56470abaddb8b16786f360.jpg"
                        }],
                        "description": null
                    },
                    {
                        "id": 7,
                        "name": "Cheese Cake",
                        "unitPrice": 5.99,
                        "rating": 0.0,
                        "contents": [{
                            "relativePath": "localhost/AdminUI/uploads/17d9db703773460cb144ddae73db8dd2.jpg"
                        }],
                        "description": null
                    },
                    {
                        "id": 8,
                        "name": "Salad",
                        "unitPrice": 5.99,
                        "rating": 0.0,
                        "contents": [{
                            "relativePath": "localhost/AdminUI/uploads/6e3198faad284c3f988a8eaac962e45b.jfif"
                        }],
                        "description": null
                    },
                    {
                        "id": 9,
                        "name": "Banana and Mandarin Buns",
                        "unitPrice": 12.99,
                        "rating": 0.0,
                        "contents": [{
                            "relativePath": "localhost/AdminUI/uploads/37191682f9984e209b7b78eaf664173c.jpg"
                        }],
                        "description": null
                    }
                ]
            },
            {
                "id": 3,
                "name": "Desserts",
                "products": [{
                    "id": 3,
                    "name": "Supangle",
                    "unitPrice": 5.99,
                    "rating": 0.0,
                    "contents": [{
                        "relativePath": "localhost/AdminUI/uploads/e335077e4f4d45b584745a4126ebe607.jpg"
                    }],
                    "description": null
                }]
            },
            {
                "id": 4,
                "name": "Main Dishes",
                "products": [

                ]
            },
            {
                "id": 5,
                "name": "Soda",
                "products": [

                ]
            },
            {
                "id": 6,
                "name": "kebab",
                "products": [

                ]
            },
            {
                "id": 7,
                "name": "çorba",
                "products": [

                ]
            }
        ];
        return products;
        // return await this.productRepository.getAll(restaurantName);
    }

}