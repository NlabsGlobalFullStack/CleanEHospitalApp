import { DepartmentModel } from "./department.model";
import { PersonalModel } from "./abstractions/personal.model";

export class NurseModel extends PersonalModel{
    shift: ShiftModel = new ShiftModel();
    shiftValue: number = 0;

    departmentId: string = "";
    department: DepartmentModel = new DepartmentModel();
    departmentName: string = "";
}

export class ShiftModel{
    name: string = "";
    value: number = 0;
}