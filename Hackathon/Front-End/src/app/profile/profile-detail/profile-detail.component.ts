import { OfficeService } from '../../office/office.service';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PoNotificationService } from '@po-ui/ng-components';
import { Profile } from '../profile.model';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-profile-detail',
  templateUrl: './profile-detail.component.html',
  styleUrls: ['./profile-detail.component.css']
})
export class ProfileDetailComponent implements OnInit {

  title = 'Meu Perfil';

  profileForm: FormGroup;

  private id;

  readonly genreOptions = [
    { value: 'male', label: 'Masculino' },
    { value: 'female', label: 'Feminino' },
    { value: 'another', label: 'Outro' },
  ];

  constructor(
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private notification: PoNotificationService,
    private router: Router,
    private profileService: ProfileService,
    private cargoService:OfficeService) {

      const { id } = this.activatedRoute.snapshot.params;

      this.id = id;
  }

  ngOnInit() {
    this.profileForm = this.fb.group({
      name: ['Maria', Validators.required],
      sobrenome: ['Silva Medeiros', Validators.required],
      email: ['maria.silva@totvs.com.br', Validators.required],
      birthday: ['2020-07-01'],
      genre: [''],
      cpf: ['', Validators.required],
      zipcode: ['', Validators.required],
      address_number: []
    });

    //this.loadData(this.id);

    this.cargoService.ler();
  }

  private loadData(id: number) {
    if (id) {
      this.profileService.get(id).subscribe((profile: Profile) => {
        this.profileForm.patchValue(profile);

        this.title = profile.name;
      });
    }
  }

  cancel() {
    window.history.back();
  }

  save() {
    if (this.profileForm.invalid) {
      this.markAsDirtyInvalidControls(this.profileForm.controls);
      this.notification.warning('Formulário precisa ser preenchido corretamente.');
      return;
    }

    const profile = this.profileForm.value;

    const operation = !!this.id
      ? this.profileService.update(this.id, profile)
      : this.profileService.save(profile);

    const successMessage = !!this.id ? 'Perfil atualizado com sucesso' : 'Perfil salvo com sucesso';

    operation.subscribe(() => {
      this.notification.success(successMessage);

      this.router.navigate(['app/profiles']);
    });

  }

  private markAsDirtyInvalidControls(controls: { [key: string]: AbstractControl }) {
    for (const key in controls) {
      if (controls.hasOwnProperty(key)) {
        const control = controls[key];

        if (control.invalid) {
          control.markAsDirty();
        }
      }
    }
  }

}
