import { DepartmentModel } from "./department.model";
import { PersonalModel } from "./abstractions/personal.model";

export class EmployeeModel extends PersonalModel{
    departmentId: string = "";
    department: DepartmentModel = new DepartmentModel();
    departmentName: string = "";

    position: PositionModel = new PositionModel();
    positionValue: number = 0;
}

export class PositionModel{
    name: string = "";
    value: number = 0;
}