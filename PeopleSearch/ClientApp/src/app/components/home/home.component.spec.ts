import { HomeService } from './home.service';
import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home.component';
import { HomeServiceMock } from '../../mocks/home.service.mock';

describe('HomeComponent', () => {
    let comp: HomeComponent;
    let fixture: ComponentFixture<HomeComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [
                HomeComponent
            ],
            imports: [
                FormsModule
            ],
            providers: [
                { provide: HomeService, useClass: HomeServiceMock }
            ]
        }).compileComponents().then(() => {
            fixture = TestBed.createComponent(HomeComponent);
            comp = fixture.componentInstance; // HomeComponent test instance
        });
    }));

    it(`should have two People`, async(() => {
        comp.GetPeople();
        expect(comp.peopleList.length).toEqual(2);
    }));

    it(`should have one People when search by name`, async(() => {
        comp.searchName = 'Messy';
        comp.SearchByName();
        expect(comp.peopleList.length).toEqual(1);
    }));

    it(`should test the table`, async(() => {
        fixture.detectChanges();
        fixture.whenStable().then(() => {
            fixture.detectChanges();

            let tableRows = fixture.nativeElement.querySelectorAll('tr');
            expect(tableRows.length).toBe(3);

            // Header row
            let headerRow = tableRows[0];
            expect(headerRow.cells[0].innerHTML).toBe('Picture');
            expect(headerRow.cells[1].innerHTML).toBe('First Name');
            expect(headerRow.cells[2].innerHTML).toBe('Last Name');

            // Data rows
            let row1 = tableRows[1];
            expect(row1.cells[1].innerHTML).toBe('Messy');
            expect(row1.cells[2].innerHTML).toBe('Tyler');
            expect(row1.cells[3].innerHTML).toBe('25');
        });
    }));
});
