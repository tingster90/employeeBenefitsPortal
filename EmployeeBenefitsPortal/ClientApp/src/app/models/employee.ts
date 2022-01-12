import { Person } from "./person";
import { Dependent } from "./dependent";

export interface Employee extends Person {
    dependents: Dependent[];
}