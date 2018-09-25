import { IInstitute } from "./institute";

export interface ILocation {
    id: number;
    street: string;
    suburb: string;
    postcode: string;
    state: string;
    country: string;
    isdeleted?: boolean;
    instituteId: number;
    institute: IInstitute;
}