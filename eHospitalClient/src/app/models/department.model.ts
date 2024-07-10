import { EntityModel } from "./abstractions/entity.model";

export class DepartmentModel extends EntityModel{
    name: string = "";
    image: string = "";
    file?: any;
    description?: string = "";
}