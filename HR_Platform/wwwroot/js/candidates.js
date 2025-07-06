export function getCandidates() {
    fetch('/api/JobCandidates')
        .then(response => response.json())
        .then(data => _displayCandidates(data))
        .catch(error => console.error('Unable to get candidates.', error));
}

export function setupCandidateListeners() {
    document.getElementById("add-candidate").addEventListener("click", addCandidate);
    document.getElementById("delete-candidate").addEventListener("click", deleteCandidate);
}

function _displayCandidates(data) {
    const ul = document.getElementById("candidate-list");
    data.forEach(candidate => {
        const li = document.createElement('li');
        li.textContent = `${candidate.firstName} ${candidate.lastName}`;
        ul.appendChild(li);
    });
}

function addCandidate() {
    const candidateName = prompt('Enter candidate FirstName LastName:').split(' ');
    const candidate = {
        firstName: candidateName[0],
        lastName: candidateName[1]
    }

    fetch('/api/JobCandidates', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(candidate)
    })
        .then(response => {
            if (!response.ok) throw new Error("Failed to add candidate.");
            alert("Candidate added!");
        })
        .catch(error => console.error('Unable to add candidate.', error));
}

function deleteCandidate() {
    const guid = prompt('Enter candidate Guid to delete it:');

    fetch(`/api/JobCandidates/${guid}`, {
        method: 'DELETE'
    })
        .then(response => response.ok)
        .catch(error => console.error('Unable to delete candidate.', error));
}