let fileInput = document.querySelector("input[type='file']");
let imageContainer = document.querySelector("#preview-container .row");

let fileInputChangeHandler = (event) => {
    let fileArray = Array.from(event.target.files);
    for (let file of fileArray) {
        let url = URL.createObjectURL(file);
        let preview = document.createElement("div");
        preview.classList.add("col-md-4", "preview-item");
        preview.innerHTML = `<img src=${url} height="100%" width="100%"/>`;

        imageContainer.appendChild(preview);
    }
    //CREATE IMAGE PREVIEW
};

fileInput.addEventListener("change", fileInputChangeHandler);