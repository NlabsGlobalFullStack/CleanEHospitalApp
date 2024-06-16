import { UserModel } from "./user.model";

export class SpecialtyModel{
    id: string = "";
    name: string = "";
    doctors: UserModel[] = [];    
    nurses: UserModel[] = []; 
    employes: UserModel[] = [];
}