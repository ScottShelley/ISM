import { ICourseInstitute } from "./course-institute";

export interface ICourse {
    id: number;
    name: string;
    level: string;
    description: string;
    imgurl: string;
    code?: string;
    overview?: string;
    entryRequirements?: string;
    careers?: string;
    isDeleted?: boolean;
    courseInstitute?: ICourseInstitute[];
}