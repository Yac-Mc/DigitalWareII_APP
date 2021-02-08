import Swal, { SweetAlertIcon, SweetAlertResult } from "sweetalert2";

import { Injectable } from "@angular/core";

@Injectable({
	providedIn: "root",
})
export class AlertsService {
	constructor() {}

	getShowAlert(
		title?: string,
		message?: string,
		iconAlert: string = "success",
		showCancelButton: boolean = false,
		confirmButtonText: string = "OK"
	) {
		this.closeAlert();
		return new Promise<SweetAlertResult>((resolve) => {
			Swal.fire({
				title,
				html: message,
				icon: iconAlert as SweetAlertIcon,
				showCancelButton,
				confirmButtonText,
			}).then((resp) => {
				return resolve(resp);
			});
		});
	}

	getShowLoading(message: string, iconAlert: string = "info") {
		this.closeAlert();
		Swal.fire({
			allowOutsideClick: false,
			text: message,
			icon: iconAlert as SweetAlertIcon,
		});
		Swal.showLoading();
	}

	closeAlert() {
		Swal.close();
	}
}
