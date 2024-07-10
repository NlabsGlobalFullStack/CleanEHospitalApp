export class EntityModel{
    id: string = "";
    createdUser: string = "";
    createdDate: string = "";

    updatedUser?: string = "";
    updatedDate?: string = "";
    isUpdated: boolean = false;

    deletedUser?: string = "";
    deletedDate?: string = "";
    isDeleted: boolean = false;
}