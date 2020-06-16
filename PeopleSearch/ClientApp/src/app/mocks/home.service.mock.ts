import { Injectable } from '@angular/core';
import { IPeople } from '../components/home/people.interface';
import { Observable, of } from 'rxjs';
import { filter, map } from 'rxjs/operators';

@Injectable()
export class HomeServiceMock {
    constructor() { }

    getPeople(): Observable<IPeople[]> {
        return of([
            {
                firstName: 'Messy',
                lastName: 'Tyler',
                age: 25,
                address: 'TestAddress1',
                interest: 'TestInterest1',
                imageUrl: ''
            },
            {
                firstName: 'Joshua',
                lastName: 'Li',
                age: 35,
                address: 'TestAddress2',
                interest: 'TestInterest2',
                imageUrl: ''
            }
        ]);
    }

    searchByName(name): Observable<IPeople[]> {
        return this.getPeople().pipe(map((item : IPeople[]) =>  item.filter(p=> p.firstName === name || p.lastName === name)));
    }
}
