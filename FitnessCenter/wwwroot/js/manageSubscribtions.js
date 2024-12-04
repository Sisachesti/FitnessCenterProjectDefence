function openManageSubscribtionsModal(gymId) {
    fetch(`https://localhost:7078/SubscribtionApi/GetClassesByGym/${gymId}`, {
        method: 'GET',
        credentials: 'include'
    })
        .then(response => response.json())
        .then(classes => {
            renderClassesInModal(classes);
            $('#manageSubscribtionsModal').modal('show');
        })
        .catch(error => {
            console.error("Error loading classes:", error);
            alert("An error occurred while loading classes.");
        });
}

function renderClassesInModal(viewModel) {
    let modalHtml = `
        <div id="manageSubscribtionsModal" class="modal fade" tabindex="-1" aria-labelledby="manageSubscribtionsModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Manage Subscribtions</h5>
                        <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Duration</th>
                                    <th>Available Subscribtions</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>`;

    viewModel.classes.forEach(classM => {
        modalHtml += `
            <tr>
                <td>${classM.title}</td>
                <td>${classM.duration}</td>
                <td><input type="number" id="availableSubscribtions-${classM.id}" value="${classM.availableSubscribtions}" min="0" class="form-control" /></td>
                <td><button class="btn btn-primary" onclick="updateAvailableSubscribtions('${classM.id}', '${viewModel.id}')">Update</button></td>
            </tr>`;
    });

    modalHtml += `
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>`;


    document.getElementById("manageSubscribtionsModalContainer").innerHTML = modalHtml;
}

function updateAvailableSubscribtions(classId, gymId) {
    const availableSubscribtions = document.getElementById(`availableSubscribtions-${classId}`).value;

    fetch('https://localhost:7078/SubscribtionApi/UpdateAvailableSubscribtions', {
        method: 'POST',
        credentials: 'include',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            GymId: gymId,
            ClassId: classId,
            AvailableSubscribtions: parseInt(availableSubscribtions, 10)
        })
    })
        .then(response => {
            if (!response.ok) throw new Error("Failed to update subscribtions.");
            alert("Subscribtion availability updated successfully.");
        })
        .catch(error => {
            console.error("Error:", error);
            alert("An error occurred while updating subscribtions.");
        });
}

function buySubscribtionsModal(gymId, classId) {
    fetch(`https://localhost:7078/SubscribtionApi/GetSubscribtionsAvailability`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            GymId: gymId,
            ClassId: classId
        })
    })
        .then(response => response.json())
        .then(viewModel => {
            $("#gymId").val(viewModel.gymId);
            $("#classId").val(viewModel.classId);
            $("#Quantity").prop("min", "1");
            $("#Quantity").prop("max", `${viewModel.availableSubscribtions}`);
            $("#AvailableSubscribtions").val(viewModel.availableSubscribtions);
            $('#buySubscribtionModal').modal('show');
        })
        .catch(error => {
            console.error("Error loading classes:", error);
            alert("An error occurred while loading classes.");
        });
}