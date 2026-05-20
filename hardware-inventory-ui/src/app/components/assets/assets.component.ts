import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AssetService } from '../../services/asset.service';
import { Asset } from '../../models/asset';

@Component({
  selector: 'app-assets',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './assets.component.html',
  styleUrls: ['./assets.component.css']
})
export class AssetsComponent implements OnInit {

  assets: Asset[] = [];

  newAsset: Asset = {
    assetName: '',
    assetType: '',
    status: ''
  };

  constructor(private assetService: AssetService) { }

  ngOnInit(): void {
    this.loadAssets();
  }

  loadAssets(): void {
    this.assetService.getAssets().subscribe(data => {
      this.assets = data;
    });
  }

  addAsset(): void {
    this.assetService.addAsset(this.newAsset).subscribe(() => {

      this.newAsset = {
        assetName: '',
        assetType: '',
        status: ''
      };

      this.loadAssets();
    });
  }

  deleteAsset(id: number): void {
    this.assetService.deleteAsset(id).subscribe(() => {
      this.loadAssets();
    });
  }
}