import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFromCardComponent } from './add-from-card.component';

describe('AddFromCardComponent', () => {
  let component: AddFromCardComponent;
  let fixture: ComponentFixture<AddFromCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddFromCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddFromCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
