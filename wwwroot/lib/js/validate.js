document.addEventListener("DOMContentLoaded", function () {
    document.querySelector("form#request").addEventListener("submit", function (e) {
        e.preventDefault(); // جلوگیری از ارسال فرم پیش از اعتبارسنجی

        // دریافت مقادیر ورودی‌ها
        const name = document.querySelector("input[name='Name']").value.trim();
        const phone = document.querySelector("input[name='Phone']").value.trim();
        const email = document.querySelector("input[name='Email']").value.trim();
        const address = document.querySelector("input[name='Address']").value.trim();
        const message = document.querySelector("input[name='Message']").value.trim();

        // الگوی بررسی ایمیل
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        // بررسی شرایط
        if (name.length < 5) {
            alert("نام و نام خانوادگی باید حداقل ۵ کاراکتر باشد.");
            return;
        }

        if (phone.length < 11 || isNaN(phone)) {
            alert("شماره تماس باید عدد و حداقل ۱۱ رقم باشد.");
            return;
        }

        if (!emailRegex.test(email)) {
            alert("لطفاً یک ایمیل معتبر وارد کنید.");
            return;
        }

        if (address.length < 10) {
            alert("آدرس باید حداقل ۱۰ کاراکتر باشد.");
            return;
        }

        if (message.length < 5) {
            alert("پیام باید حداقل ۵ کاراکتر باشد.");
            return;
        }

        alert("فرم با موفقیت ارسال شد!");
        this.submit(); // ارسال فرم در صورت معتبر بودن
    });
});