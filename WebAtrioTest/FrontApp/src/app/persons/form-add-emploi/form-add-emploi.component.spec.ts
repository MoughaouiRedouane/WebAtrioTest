import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormAddEmploiComponent } from './form-add-emploi.component';

describe('FormAddEmploiComponent', () => {
  let component: FormAddEmploiComponent;
  let fixture: ComponentFixture<FormAddEmploiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FormAddEmploiComponent]
    });
    fixture = TestBed.createComponent(FormAddEmploiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
