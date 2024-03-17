



// Sayfa tamamen yüklendiğinde bu fonksiyon çalışacak
$(document).ready(function () {
    // searchInput elementi üzerinde bir input olayı (yani kullanıcının yazma eylemi) dinleniyor
    $('#searchInput').on('input', function () {
        // Kullanıcının girdiği değeri alıyoruz
        var searchValue = $(this).val();
        // Girilen değerin uzunluğu 2 veya daha fazlaysa işlem yapılacak
        var newurl = window.location.href;
        if (searchValue.length >= 2) {
            // AJAX isteği yapılıyor
            $.ajax({
                // İstek yapılacak URL
                url: newurl, // Burada URL'i belirlemeniz gerekiyor
                // HTTP methodu (GET, POST, vb.)
                method: 'GET',
                // Sunucuya gönderilecek veri (arama değeri)
                data: { searchString: searchValue },
                // İstek başarılı olduğunda çalışacak fonksiyon
                success: function (data) {

                    // Sunucudan gelen veriyi #searchResults elementi içine yerleştiriyoruz
                    $('#searchResults').html(data);

                },
                // İstek başarısız olduğunda çalışacak fonksiyon
                error: function (xhr, status, error) {
                    // Hata durumunda konsola hata mesajını yazdırıyoruz
                    console.error(xhr.responseText);
                }
            });
        }
    });
});




