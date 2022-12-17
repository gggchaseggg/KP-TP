export default function serialize(form) {
  if (!form || form.nodeName !== "FORM") {
    return;
  }
  var i, j = [];
  let q = {};
  for (i = 0; i < form.elements.length - 1; i++) {
    if (form.elements[i].name === "") continue
    q[form.elements[i].name] = []
  }
  for (i = 0; i < form.elements.length - 1; i++) {
    if (form.elements[i].name === "") {
      continue;
    }
    switch (form.elements[i].nodeName) {
      case 'INPUT':
        switch (form.elements[i].type) {
          case 'checkbox':
          case 'radio':
            if (form.elements[i].checked) {
              q[form.elements[i].name].push(encodeURIComponent(form.elements[i].value))
            } else {
              q[form.elements[i].name].push("")
            }
            break;
        }
        break;
    }
  }
  return q;
}