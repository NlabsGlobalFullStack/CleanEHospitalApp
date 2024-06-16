import { DepartmentModel } from "./department.model";

export class EmployeeModel{
    id: string = "";
    department: DepartmentModel = new DepartmentModel();
    departmentValue: number = 0;
}