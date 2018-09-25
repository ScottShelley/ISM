import { ICourse } from "./course";
import { IInstitute } from "./institute";
import { ICourseLocation } from "./course-location";

export interface ICourseInstitute {
    course?: ICourse;
    courseId: number;
    courseLocations?: ICourseLocation[];
    durationWeeks: number;
    id: number;
    institute?: IInstitute;
    institutionId: number;
    isDeleted?: boolean;
    nonTution?: string;
    total?: string;
    tution: string;
}