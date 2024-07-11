import { EmployeeModel } from "./employee.model";
import { VehicleOperationTypeEnum } from "./enums/vehicle-operation-type-enum.model";
import { VehicleModel } from "./vehicle.model";

export class VehicleActionModel{
    id: string = "";

    employeeId: string = "";
    employee: EmployeeModel = new EmployeeModel();

    vehicleId: string = "";
    vehicle: VehicleModel = new VehicleModel();

    vehicleOperation: VehicleOperationTypeEnum = new VehicleOperationTypeEnum();
    vehicleOperationValue: number = 0;

    description: string = "";
    
    createdUser: string = "";
    createdDate: string = "";

    updatedUser: string = "";
    updatedDate: string = "";
    isUpdated: boolean = false;
}