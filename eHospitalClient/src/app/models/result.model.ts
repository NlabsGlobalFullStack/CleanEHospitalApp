export class ResultModel<T>{
    data: any;
    errorMessages?: string[];
    isSuccessful: boolean = true;
    statusCode: number = 200;
}