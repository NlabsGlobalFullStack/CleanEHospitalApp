import { VehicleActionModel } from "./vehicle-action.model";
import { VehicleMissionModel } from "./vehicle-mission.model";

export class VehicleModel{
    id: string = "";
    plate: string = "";
    vehicleType: VehicleTypeModel = new VehicleTypeModel();
    vehicleTypeValue: number = 0;
    capacity: number | undefined;

    vehicleActions: VehicleActionModel[] = [];
    vehicleMissions: VehicleMissionModel[] = [];

    createdUser: string = "";
    createdDate: string = "";

    updatedUser: string = "";
    updatedDate: string = "";
    isUpdated: boolean = false;
}

export class VehicleTypeModel{
    name: string = "";
    value: number = 0;
}