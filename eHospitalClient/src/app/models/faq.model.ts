export class FaqModel{
    id: string = "";
    createdUser: string = "";
    createdDate: string = "";

    updatedUser?: string = "";
    updatedDate?: string = "";
    isUpdated: boolean = false;

    deletedUser?: string = "";
    deletedDate?: string = "";
    isDeleted: boolean = false;
    
    question: string = "";
    answer: string = "";
    publishDate: string = "";
    isPublish: boolean = true;
}