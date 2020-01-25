// import { ToastyService } from 'ng2-toasty';
import { VechicleService } from './../services/vechicle.service';
import { FeatureService } from './../services/feature.service';
import { MakeService } from './../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  
  makes: any = [];
  models: any = [];
  features: any = [];
  vehicle: any = {
    features: [],
    contact: {}
  };
  


  constructor(private makeService: MakeService, private featureService: FeatureService, private vehicleService: VechicleService) { }

  ngOnInit() {
    

    this.makeService.getMakes().subscribe(makes_param => {
      this.makes = makes_param;
      console.log("MAKES", this.makes);
    });
    this.featureService.getFeatures().subscribe(features => this.features = features)
  }

  onMakeChange(){

    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this.vehicleService.create(this.vehicle)
    .subscribe(
      x => console.log(x),
      err => {
        // this.toastyService.error( {
        //   title: 'Error',
        //   msg: 'An unexpected error happend.',
        //   theme: 'boostrap',
        //   showClose: true,
        //   timeout: 5000,
        // })
        console.log("ERROR CREATING A NEW VEHICLE!")
      }
      
      )
    
  }

}
