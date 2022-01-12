import { Person } from "./person";
import { DependentType } from "./dependent-type";

export interface Dependent extends Person {
    type: DependentType;
}