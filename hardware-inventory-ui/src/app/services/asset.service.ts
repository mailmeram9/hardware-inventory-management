import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Asset } from '../models/asset';

@Injectable({
  providedIn: 'root'
})
export class AssetService {

  private apiUrl = 'https://localhost:7140/api/Assets';

  constructor(private http: HttpClient) { }

  getAssets(): Observable<Asset[]> {
    return this.http.get<Asset[]>(this.apiUrl);
  }

  addAsset(asset: Asset): Observable<Asset> {
    return this.http.post<Asset>(this.apiUrl, asset);
  }

  updateAsset(id: number, asset: Asset): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, asset);
  }

  deleteAsset(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}