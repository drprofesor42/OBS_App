document.querySelector("#files").onchange = function () {
    const fileName = this.files[0]?.name;
    const label = document.querySelector("label[for=files]");
    label.innerText = fileName ?? "FOTOĞRAF YÜKLE (150 X 150)";
};


