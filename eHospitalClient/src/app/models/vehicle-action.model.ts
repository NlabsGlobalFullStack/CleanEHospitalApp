import { EmployeeModel } from "./employee.model";
import { VehicleModel } from "./vehicle.model";

export class VehicleActionModel{
    id: string = "";

    employeeId: string = "";
    employee: EmployeeModel = new EmployeeModel();

    vehicleId: string = "";
    vehicle: VehicleModel = new VehicleModel();

    vehicleOperation: VehicleOperationModel = new VehicleOperationModel();
    vehicleOperationValue: number = 0;

    description: string = "";
    
    createdUser: string = "";
    createdDate: string = "";

    updatedUser: string = "";
    updatedDate: string = "";
    isUpdated: boolean = false;
}

export class VehicleOperationModel{
    value: number = 0;
    name: string = "";
}