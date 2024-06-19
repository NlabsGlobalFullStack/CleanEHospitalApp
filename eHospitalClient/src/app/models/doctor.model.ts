import { DepartmentModel } from "./department.model";
import { UserModel } from "./user.model";

export class DoctorModel{
    id: string = "";
    specialty: SpecialtyModel = new SpecialtyModel();
    specialtyValue: number = 0;
    userId: string = "";
    user: UserModel | any;
    userImage: string = "";
    departmentId: string = "";
    department: DepartmentModel | any;

    departmentName: string = "";

    fullName: string = "";
}

export class SpecialtyModel{
    name: string = "";
    value: number = 0;
}