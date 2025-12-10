// لا حاجة للكثير، فقط بعض الحركات الخفيفة
document.addEventListener("DOMContentLoaded", () => {
    const cards = document.querySelectorAll("#card");
    cards.forEach(card => {
        card.addEventListener("mousemove", e => {
            const rect = card.getBoundingClientRect();
            const x = e.clientX - rect.left - rect.width / 2;
            const y = e.clientY - rect.top - rect.height / 2;
            card.style.transform = `rotateX(${-y / 20}deg) rotateY(${x / 20}deg)`;
        });
        card.addEventListener("mouseleave", () => {
            card.style.transform = `rotateX(0deg) rotateY(0deg)`;
        });
    });
});
document.querySelectorAll('.card-actions button, .card-actions a').forEach(btn => {
    btn.addEventListener('mousedown', () => {
        btn.closest('.card').style.transform = 'rotateX(0) rotateY(0)';
    });
});
// تحريك إضافي للجسيمات أو تأثيرات مستقبلية
document.addEventListener("DOMContentLoaded", function () {
    // مثال: تحريك البطاقات عند التمرير
    const cards = document.querySelectorAll('.task-card');
    window.addEventListener('scroll', () => {
        cards.forEach(card => {
            const rect = card.getBoundingClientRect();
            if (rect.top < window.innerHeight) {
                card.style.transform = 'translateY(-5px)';
            }
        });
    });
});
