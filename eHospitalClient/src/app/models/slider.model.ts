import { EntityModel } from "./abstractions/entity.model";

export class SliderModel extends EntityModel{    
    title: string = "";
    description: string = "";
    image: string = "";

    file: any;
}