import { EntityModel } from "./abstractions/entity.model";

export class AnnouncementModel extends EntityModel{
    title: string = "";
    isPublish: boolean = true;
    publishDate: string = "";
    image: string = "";
    summary: string = "";
    content: string = "";
    file?: any;
}