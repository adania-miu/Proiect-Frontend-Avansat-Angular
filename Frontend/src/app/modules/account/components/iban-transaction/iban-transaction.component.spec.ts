import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IbanTransactionComponent } from './iban-transaction.component';

describe('IbanTransactionComponent', () => {
  let component: IbanTransactionComponent;
  let fixture: ComponentFixture<IbanTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IbanTransactionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IbanTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
