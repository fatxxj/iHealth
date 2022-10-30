


export interface User {
    id: number;
    name: string;
    surname: string;
    email: string;
    password: string;
    placeId?: any;
    clinicId: number;
    token: string;
    clinics?: any;
    place?: any;
}

export interface Value {
    message: string;
    statuscode: number;
    user: User;
}

export interface LoginResponse {
    contentType?: any;
    serializerSettings?: any;
    statusCode?: any;
    value: Value;
}


