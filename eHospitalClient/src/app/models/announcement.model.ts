export class AnnouncementModel{
    id: string = "";
    title: string = "";
    isPublish: boolean = true;
    publishDate: string = "";
    image: string = "";
    summary: string = "";
    content: string = "";

    file?: any;

    createdDate: string = "";

    isDeleted: boolean = false;
}