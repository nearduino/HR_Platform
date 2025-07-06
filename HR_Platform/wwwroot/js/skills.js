export function getSkills() {
    fetch('/api/Skills')
        .then(response => response.json())
        .then(data => _displaySkills(data))
        .catch(error => console.error('Unable to get skills.', error));
}

export function setupSkillListeners() {
    document.getElementById("add-skill").addEventListener("click", addSkill);
    document.getElementById("delete-skill").addEventListener("click", deleteSkill);
}

function _displaySkills(data) {
    const ul = document.getElementById("skill-list");
    data.forEach(skill => {
        const li = document.createElement('li');
        li.textContent = `${skill.name}`;
        ul.appendChild(li);
    });
}

function addSkill() {
    const skillName = prompt('Enter skill name:');
    const skill = {
        name: skillName
    }

    fetch('/api/Skills', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(skill)
    })
        .then(response => response.ok)
        .catch(error => console.error('Unable to add skill.', error));
}

function deleteSkill() {
    const guid = prompt('Enter skill Guid to delete it:');

    fetch(`/api/Skills/${guid}`, {
        method: 'DELETE'
    })
        .then(response => response.ok)
        .catch(error => console.error('Unable to delete skill.', error));
}

